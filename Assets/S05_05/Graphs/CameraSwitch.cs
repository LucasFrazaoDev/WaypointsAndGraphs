using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform tank;
    [SerializeField] private Camera[] cameras;
    private Camera activeCamera;

    void Start()
    {
        foreach (Camera camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        activeCamera = FindActiveCamera();

        foreach (Camera camera in cameras)
        {
            camera.gameObject.SetActive(camera == activeCamera);
            camera.enabled = camera == activeCamera;
        }
    }

    Camera FindActiveCamera()
    {
        foreach (Camera camera in cameras)
        {
            Vector3 viewportPoint = camera.WorldToViewportPoint(tank.position);

            // Verifica se o tanque est� dentro da �rea vis�vel da c�mera
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                return camera;
            }
        }

        return null; // Retorna nulo se o tanque n�o estiver vis�vel em nenhuma c�mera
    }
}
