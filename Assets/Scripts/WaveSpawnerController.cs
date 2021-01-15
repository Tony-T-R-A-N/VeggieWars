using UnityEngine;
using System.Collections;

public class WaveSpawnerController : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    int nextWave = 0;
    public Transform[] spawnPoints;
    float waveCountdown;
    float searchCountdown = 1f;
    public float timeBetweenWaves = 5f;
    SpawnState state = SpawnState.COUNTING;
    GameHUDController gameHUDController;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();

        if (spawnPoints.Length == 0) {
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        if (state == SpawnState.WAITING) {
            if (!EnemyIsAlive()) {
                WaveCompleted();
            } else {
                return;
            }
        }

        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted() {
        gameHUDController.WaveCompleteText();

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) {
            nextWave = 0;
            gameHUDController.GameOverText();
        } else {
            nextWave++;
        }   
    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f) {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false; 
            } 
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave) {
        gameHUDController.WaveNumberText(_wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++) {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy) {
        Debug.Log("Spawning Enemy; " + _enemy.name);

        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
