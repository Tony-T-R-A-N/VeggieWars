using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    public float health = 2.5f;
    public float speed = 10f;
    GameHUDController gameHUDController;
    ScoreScript scoreScript;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
        gameHUDController.IncrementEnemiesAlive();
        scoreScript = GameObject.Find("ScoreText").GetComponent<ScoreScript>();
    }

    private void FixedUpdate() {
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( -speed, 0f));
    }

    void OnCollisionEnter2D (Collision2D colInfo) {
        if (colInfo.collider.CompareTag("Player") && colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die() {
        ScoreScript.scoreValue += 50;
        gameHUDController.DecrementEnemiesAlive();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
