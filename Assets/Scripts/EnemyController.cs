using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    float health = 2.5f;
    float speed = 2.5f;
    GameHUDController gameHUDController;
    ScoreScript scoreScript;

    void Start() {
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
        scoreScript = GameObject.Find("ScoreText").GetComponent<ScoreScript>();
    }

    private void FixedUpdate() {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
    }

    void OnCollisionEnter2D (Collision2D colInfo) {
        if (colInfo.collider.CompareTag("Player") && colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die() {
        ScoreScript.scoreValue += 50;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
