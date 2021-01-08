using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    public float health = 2.5f;
    GameHUDController gameHUDController;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
        gameHUDController.IncrementEnemiesAlive();
    }

    void OnCollisionEnter2D (Collision2D colInfo) {
        if (colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die() {
        gameHUDController.DecrementEnemiesAlive();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
