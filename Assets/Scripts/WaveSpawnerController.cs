using UnityEngine;
using System.Collections;

public class WaveSpawnerController : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave {
        public string name;
        public Transform[] enemyObjects;
        public int count;
    }
    public Wave[] waves;
    public Transform[] spawnPointsObject;
    int nextWave = 0;
    float waveCountdown;
    float searchCountdown = 1f;
    float timeBetweenWaves = 3f;
    float rate;
    SpawnState state = SpawnState.COUNTING;
    GameHUDController gameHUDController;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        rate = Random.Range(1f, 3f);

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
                StopCoroutine("SpawnWave");
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

    IEnumerator SpawnWave(Wave wave) {
        gameHUDController.WaveNumberText(wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < wave.count; i++) {
            int index = Random.Range(0, wave.enemyObjects.Length);
            SpawnEnemy(wave.enemyObjects[index]);

            yield return new WaitForSeconds(rate);
        }

        state = SpawnState.WAITING;
    }

    void SpawnEnemy(Transform enemy) {
        Debug.Log("Spawning Enemy; " + enemy.name);

        Transform spawnPoint = spawnPointsObject[Random.Range(0, spawnPointsObject.Length)];
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
