using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    public float health;
    public float speed;
    GameHUDController gameHUDController;
    PlayerController playerController;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate() {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
    }

    void OnCollisionEnter2D (Collision2D colInfo) {
         if (colInfo.collider.CompareTag("Player")) {
            health -= playerController.damage;

            if (health == 0f) {
                gameHUDController.IncrementMoney(50);
                Die();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Core")) {
            gameHUDController.DecrementHealth(10);
            Die();
        }
    }

    void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
