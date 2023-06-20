using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform tank; // Referência ao transform do objeto do tanque
    [SerializeField] private Camera[] cameras; // Array contendo todas as câmeras

    void Update()
    {
        // Verifica se o tanque está visível em alguma câmera
        bool isTankVisible = false;
        foreach (Camera camera in cameras)
        {
            // Converte a posição do tanque para as coordenadas da viewport da câmera
            Vector3 viewportPoint = camera.WorldToViewportPoint(tank.position);

            // Verifica se o tanque está dentro da área visível da câmera
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                isTankVisible = true;
                break;
            }
        }

        // Ativa a câmera correta com base na visibilidade do tanque
        for (int i = 0; i < cameras.Length; i++)
        {
            // Ativa a câmera apenas se o tanque estiver visível e for a última câmera no array
            cameras[i].gameObject.SetActive(isTankVisible && i == cameras.Length - 1);

            // Ativa ou desativa o componente Camera da câmera
            cameras[i].enabled = cameras[i].gameObject.activeSelf;
        }
    }
}
