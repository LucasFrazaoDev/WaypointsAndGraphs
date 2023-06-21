using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform _tank;
    [SerializeField] private Camera[] _cameras;
    private Camera _activeCamera;

    void Start()
    {
        foreach (Camera camera in _cameras)
        {
            camera.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        _activeCamera = FindActiveCamera();

        foreach (Camera camera in _cameras)
        {
            camera.gameObject.SetActive(camera == _activeCamera);
            camera.enabled = camera == _activeCamera;
        }
    }

    Camera FindActiveCamera()
    {
        foreach (Camera camera in _cameras)
        {
            Vector3 viewportPoint = camera.WorldToViewportPoint(_tank.position);

            // Verifica se o tanque est� dentro da �rea vis�vel da c�mera
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                return camera;
            }
        }

        return null; // Retorna nulo se o tanque n�o estiver vis�vel em nenhuma c�mera
    }
}
