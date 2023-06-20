using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform tank; // Refer�ncia ao transform do objeto do tanque
    [SerializeField] private Camera[] cameras; // Array contendo todas as c�meras

    void Update()
    {
        // Verifica se o tanque est� vis�vel em alguma c�mera
        bool isTankVisible = false;
        foreach (Camera camera in cameras)
        {
            // Converte a posi��o do tanque para as coordenadas da viewport da c�mera
            Vector3 viewportPoint = camera.WorldToViewportPoint(tank.position);

            // Verifica se o tanque est� dentro da �rea vis�vel da c�mera
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                isTankVisible = true;
                break;
            }
        }

        // Ativa a c�mera correta com base na visibilidade do tanque
        for (int i = 0; i < cameras.Length; i++)
        {
            // Ativa a c�mera apenas se o tanque estiver vis�vel e for a �ltima c�mera no array
            cameras[i].gameObject.SetActive(isTankVisible && i == cameras.Length - 1);

            // Ativa ou desativa o componente Camera da c�mera
            cameras[i].enabled = cameras[i].gameObject.activeSelf;
        }
    }
}
