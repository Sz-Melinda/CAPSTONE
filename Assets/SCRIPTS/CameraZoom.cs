using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public float zoomSpeed = 5f;
    public float minFov = 20f;
    public float maxFov = 60f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float fov = cam.fieldOfView;
            fov -= scroll * zoomSpeed * 10f;
            cam.fieldOfView = Mathf.Clamp(fov, minFov, maxFov);
        }
    }
}