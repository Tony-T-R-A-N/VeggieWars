using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    public float health = 4f;
    public static int enemiesAlive = 0;

    void Start() {
        enemiesAlive++;
    }

    void OnCollisionEnter2D (Collision2D colInfo) {
        if (colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        enemiesAlive--;
        if (enemiesAlive <= 0) {
            Debug.Log("Level Won");
        }

        Destroy(gameObject);
    }
}
