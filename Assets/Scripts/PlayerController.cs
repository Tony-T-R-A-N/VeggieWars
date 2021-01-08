using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public Rigidbody2D rigidBody2D;
    Rigidbody2D hook;
    public float releaseTime = .15f;
    public float maxDragDistance = 2f;
    public GameObject nextBall;
    public GameObject deathEffect;
    bool isPressed = false;
    GameHUDController gameHUDController;

    void Start() {
        hook = GameObject.Find("hook").GetComponent<Rigidbody2D>();
        GetComponent<SpringJoint2D>().connectedBody = hook;
        gameHUDController = GameObject.Find("Canvas").GetComponent<GameHUDController>();
    }

    void Update () {
        if (isPressed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePosition, hook.position) > maxDragDistance) {
                rigidBody2D.position = hook.position + (mousePosition - hook.position).normalized * maxDragDistance;
            } else {
                rigidBody2D.position = mousePosition;
            }
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
    }

    IEnumerator Release () {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        enabled = false;

        yield return new WaitForSeconds(4f);

        if (nextBall != null) {
            nextBall.SetActive(true);
        } else {
            gameHUDController.ShowGameOverButtons();
        }
        
        yield return new WaitForSeconds(4f);
        
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
