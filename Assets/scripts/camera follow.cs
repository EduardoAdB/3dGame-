using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O personagem a ser seguido
    public Vector3 offset = new Vector3(0, 2, -5); // Posi��o inicial da c�mera em rela��o ao personagem
    public float rotationSpeed = 5f; // Velocidade de rota��o da c�mera
    public float heightOffset = 2f; // Altura ajust�vel da c�mera

    private float currentYaw = 0f; // �ngulo de rota��o horizontal

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Nenhum alvo definido.");
            return;
        }

        // Rota��o ao redor do personagem
        if (Input.GetMouseButton(1)) // Bot�o direito do mouse pressionado
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            currentYaw += mouseX;
        }

        // Calcula a nova posi��o da c�mera com altura ajust�vel
        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);
        Vector3 adjustedOffset = new Vector3(offset.x, heightOffset, offset.z);
        Vector3 desiredPosition = target.position + rotation * adjustedOffset;

        // Move a c�mera para a nova posi��o
        transform.position = desiredPosition;
        transform.LookAt(new Vector3(target.position.x, target.position.y + heightOffset, target.position.z)); // Mant�m a c�mera olhando para o personagem
    }
}