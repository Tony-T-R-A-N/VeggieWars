﻿using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;
    public float health = 4f;
    public static int enemiesAlive = 0;
    public GameObject canvas;

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
            canvas.SetActive(true);
        }

        Destroy(gameObject);
    }
}
