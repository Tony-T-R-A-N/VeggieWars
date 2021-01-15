using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    public float health = 2.5f;
    public float speed = 10f;
    GameHUDController gameHUDController;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
        gameHUDController.IncrementEnemiesAlive();
    }

    private void FixedUpdate() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( -speed, 0f));
    }

    void OnCollisionEnter2D (Collision2D colInfo) {
        if (colInfo.otherCollider.CompareTag("Player") && colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die() {
        gameHUDController.DecrementEnemiesAlive();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
