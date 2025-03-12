using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Velocidade de movimento do personagem
    public Transform orientation; // Refer�ncia � orienta��o do personagem (normalmente o pr�prio transform)

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
            Debug.LogWarning("CharacterMovement: Nenhuma refer�ncia de orienta��o atribu�da.");
            return;
        }

        // Captura a entrada do jogador (WASD ou setas direcionais)
        float moveHorizontal = Input.GetAxis("Horizontal");  // A/D ou seta direita/esquerda
        float moveVertical = Input.GetAxis("Vertical");  // W/S ou seta cima/baixo

        // Calcula a dire��o do movimento com base na rota��o do personagem
        Vector3 moveDir = orientation.right * moveHorizontal + orientation.forward * moveVertical;
        moveDir.y = 0; // Garante que o movimento fique no plano horizontal
        moveDir.Normalize();

        // Aplica o movimento
        rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
    }
}
