using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform _tank;
    [SerializeField] private Camera[] _cameras;
    private Camera _activeCamera;

    private void Start()
    {
        foreach (Camera camera in _cameras)
        {
            camera.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _activeCamera = FindActiveCamera();

        foreach (Camera camera in _cameras)
        {
            camera.gameObject.SetActive(camera == _activeCamera);
            camera.enabled = camera == _activeCamera;
        }
    }

    private Camera FindActiveCamera()
    {
        foreach (Camera camera in _cameras)
        {
            Vector3 viewportPoint = camera.WorldToViewportPoint(_tank.position);

            // Checks if the tank is within the camera's visible area
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                return camera;
            }
        }

        return null; // Returns null if the tank is not visible on any camera
    }
}
