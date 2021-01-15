using UnityEngine;

public class CameraDragController : MonoBehaviour {

    public float dragSpeed = .5f;
    static int scrollThresholdMin = Screen.width / 4;
    static int scrollThresholdMax = scrollThresholdMin * 3;

    void Update() {
        float mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        float positionX = mousePosition * dragSpeed;
        Vector2 move = new Vector2(-positionX, 0f);

        if (mousePosition <= scrollThresholdMin) {
            if (mousePosition < 0f) {

            }

            transform.Translate(move, Space.World);
        } else if (mousePosition >= scrollThresholdMax) {
            if (mousePosition < Screen.width) {

            }

            transform.Translate(move, Space.World);
        }
    }
}
