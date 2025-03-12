using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform cameraTransform; // Referência à câmera
    public float rotationSpeed = 5f; // Velocidade da rotação

    void Update()
    {
        if (cameraTransform == null)
        {
            Debug.LogWarning("RotateTowardsCamera: Nenhuma câmera atribuída.");
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Obtém a direção da câmera no plano horizontal
            Vector3 cameraDirection = cameraTransform.forward;
            cameraDirection.y = 0; // Mantém a rotação apenas na horizontal

            if (cameraDirection != Vector3.zero)
            {
                // Calcula a rotação necessária para virar o personagem de costas para a câmera
                Quaternion targetRotation = Quaternion.LookRotation(cameraDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
