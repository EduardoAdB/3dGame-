using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O personagem a ser seguido
    public Vector3 offset = new Vector3(0, 2, -5); // Posição inicial da câmera em relação ao personagem
    public float rotationSpeed = 5f; // Velocidade de rotação da câmera
    public float heightOffset = 2f; // Altura ajustável da câmera

    private float currentYaw = 0f; // Ângulo de rotação horizontal

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Nenhum alvo definido.");
            return;
        }

        // Rotação ao redor do personagem
        if (Input.GetMouseButton(1)) // Botão direito do mouse pressionado
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            currentYaw += mouseX;
        }

        // Calcula a nova posição da câmera com altura ajustável
        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);
        Vector3 adjustedOffset = new Vector3(offset.x, heightOffset, offset.z);
        Vector3 desiredPosition = target.position + rotation * adjustedOffset;

        // Move a câmera para a nova posição
        transform.position = desiredPosition;
        transform.LookAt(new Vector3(target.position.x, target.position.y + heightOffset, target.position.z)); // Mantém a câmera olhando para o personagem
    }
}