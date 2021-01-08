using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{

    Rigidbody2D rigidbody;
    public Rigidbody2D hook;
    public float releaseTime = .15f;
    public float maxDragDistance = 2f;
    public GameObject nextBall;
    public GameObject deathEffect;
    bool isPressed = false;
    public static int numberOfTries = 3;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (isPressed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePosition, hook.position) > maxDragDistance) {
                rigidbody.position = hook.position+(mousePosition-hook.position).normalized*maxDragDistance;
            } else {
                rigidbody.position = mousePosition;
            }
        }
    }

    void OnMouseDown () {
        isPressed = true;
        rigidbody.isKinematic = true;
    }

    void OnMouseUp () {
        isPressed = false;
        rigidbody.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release () {
        numberOfTries--;
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);

        if (numberOfTries > 0) {
            nextBall.SetActive(true);
        } else {
            Debug.Log("Try Again");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        yield return new WaitForSeconds(5f);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
