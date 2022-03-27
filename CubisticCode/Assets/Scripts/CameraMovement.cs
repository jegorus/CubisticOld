using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 0, -10);
    public Transform playerPosition;
    public GameManagerScript levelManager;
    public float cameraSpeed = 0.5f;

    private void FixedUpdate()
    {
        if (playerPosition != null && !levelManager.ShouldRestart())
            transform.position = Vector3.Lerp(transform.position, playerPosition.position + offset, cameraSpeed);
    }
}
