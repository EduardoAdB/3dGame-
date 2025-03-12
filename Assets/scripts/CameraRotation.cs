using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform cameraTransform; // Refer�ncia � c�mera
    public float rotationSpeed = 5f; // Velocidade da rota��o

    void Update()
    {
        if (cameraTransform == null)
        {
            Debug.LogWarning("RotateTowardsCamera: Nenhuma c�mera atribu�da.");
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Obt�m a dire��o da c�mera no plano horizontal
            Vector3 cameraDirection = cameraTransform.forward;
            cameraDirection.y = 0; // Mant�m a rota��o apenas na horizontal

            if (cameraDirection != Vector3.zero)
            {
                // Calcula a rota��o necess�ria para virar o personagem de costas para a c�mera
                Quaternion targetRotation = Quaternion.LookRotation(cameraDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
