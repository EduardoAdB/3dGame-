using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Velocidade de movimento do personagem
    public Transform orientation; // Referência à orientação do personagem (normalmente o próprio transform)

    private Rigidbody rb;

    void Start()
    {
        // Pega o Rigidbody do personagem
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (orientation == null)
        {
            Debug.LogWarning("CharacterMovement: Nenhuma referência de orientação atribuída.");
            return;
        }

        // Captura a entrada do jogador (WASD ou setas direcionais)
        float moveHorizontal = Input.GetAxis("Horizontal");  // A/D ou seta direita/esquerda
        float moveVertical = Input.GetAxis("Vertical");  // W/S ou seta cima/baixo

        // Calcula a direção do movimento com base na rotação do personagem
        Vector3 moveDir = orientation.right * moveHorizontal + orientation.forward * moveVertical;
        moveDir.y = 0; // Garante que o movimento fique no plano horizontal
        moveDir.Normalize();

        // Aplica o movimento
        rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
    }
}
