using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject deathEffect;
    Rigidbody2D rigidBody2D;
    Rigidbody2D hook;
    GameHUDController gameHUDController;
    public int damage;
    float releaseTime = .15f;
    float maxDragDistance = 2f;
    bool isPressed = false;

    void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        hook = GameObject.Find("hook").GetComponent<Rigidbody2D>();
        GetComponent<SpringJoint2D>().connectedBody = hook;
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
    }

    void Update () {
        if (isPressed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePosition, hook.position) > maxDragDistance) {
                rigidBody2D.position = hook.position + (mousePosition - hook.position).normalized * maxDragDistance;
            } else {
                rigidBody2D.position = mousePosition;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy")) {
            StopCoroutine(Release());
            StopCoroutine(StartResetPlayer());
            ResetPlayer();
        }
    }

    void OnMouseDown () {
        isPressed = true;
        rigidBody2D.isKinematic = true;
    }

    void OnMouseUp () {
        isPressed = false;
        rigidBody2D.isKinematic = false;
        StartCoroutine(Release());
        StopCoroutine(Release());
        StartCoroutine(StartResetPlayer());
        StopCoroutine(StartResetPlayer());
    }

    IEnumerator Release() {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
    }

    IEnumerator StartResetPlayer() {
        yield return new WaitForSeconds(8f);

        ResetPlayer();
    }

    void ResetPlayer() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        transform.position = hook.position;
        isPressed = false;
        rigidBody2D.isKinematic = true;
        rigidBody2D.velocity = new Vector2(0f, 0f);
        GetComponent<SpringJoint2D>().enabled = true;
    }
}
