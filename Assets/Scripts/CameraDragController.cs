using UnityEngine;

public class CameraDragController : MonoBehaviour {

    float dragSpeed = 10f;
    static float scrollThresholdMin = .05f;
    static float scrollThresholdMax = .95f;

    void Update() {
        float cameraPosition = Camera.main.transform.position.x;
        float mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        float movementSpeed = dragSpeed * Time.deltaTime;
        Vector2 move = new Vector2(movementSpeed, 0f);
        
        if (mousePosition <= scrollThresholdMin) {
            if (cameraPosition - movementSpeed <= -5f) {
                transform.position = new Vector3(-5f, 0f, -10f);
            } else {
                transform.Translate(-move, Space.World);
            }
        } else if (mousePosition + movementSpeed >= scrollThresholdMax) {
            if (cameraPosition >= 5f) {
                transform.position = new Vector3(5f, 0f, -10f);
            } else {
                transform.Translate(move, Space.World);
            }
        }
    }
}
