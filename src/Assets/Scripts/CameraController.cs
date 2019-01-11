using UnityEngine;

public class CameraController : MonoBehaviour {
    public float cameraSpeed;
    public float minZoom;
    public float maxZoom;
    public float maxX;
    public float maxY;

    private void Update() {
        if ((Input.mousePosition.x <= 10 || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > -this.maxX) {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime, Space.Self);
        }

        if ((Input.mousePosition.x >= Screen.width - 10 || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < this.maxX) {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime, Space.Self);
        }

        if ((Input.mousePosition.y <= 10 || Input.GetKey(KeyCode.DownArrow)) && transform.position.z > -this.maxY) {
            transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
        }

        if ((Input.mousePosition.y >= Screen.height - 10 || Input.GetKey(KeyCode.UpArrow)) && transform.position.z < this.maxY) {
            transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
        }

        var scroll = Input.mouseScrollDelta.y;
        if (scroll < 0f && transform.position.y < this.maxZoom) {
            transform.position -= transform.forward * cameraSpeed;
        }

        else if (scroll > 0f && transform.position.y > this.minZoom) {
            transform.position += transform.forward * cameraSpeed;
        }
    }
}