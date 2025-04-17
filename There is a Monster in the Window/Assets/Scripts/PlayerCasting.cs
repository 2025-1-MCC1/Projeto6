using UnityEngine;

// Script responsável por medir a distância entre o jogador e o objeto que ele está olhando
public class PlayerCasting : MonoBehaviour
{
    // Variável estática para armazenar a distância que pode ser acessada por outros scripts
    public static float distanceFromTarget;

    // Variável visível no Inspector para visualização no Editor, usada internamente para armazenar a distância
    [SerializeField] float toTarget;

    // Chamado a cada frame
    void Update()
    {
        RaycastHit hit;

        // Realiza um Raycast (raio) a partir da posição do jogador na direção que ele está olhando (frente)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            // Se o raio colidir com algum objeto, salva a distância até o objeto atingido
            toTarget = hit.distance;

            // Atualiza a variável estática com a distância para que outros scripts possam usar
            distanceFromTarget = toTarget;
        }
    }
}
