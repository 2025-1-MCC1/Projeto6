using UnityEngine;

// Script respons�vel por medir a dist�ncia entre o jogador e o objeto que ele est� olhando
public class PlayerCasting : MonoBehaviour
{
    // Vari�vel est�tica para armazenar a dist�ncia que pode ser acessada por outros scripts
    public static float distanceFromTarget;

    // Vari�vel vis�vel no Inspector para visualiza��o no Editor, usada internamente para armazenar a dist�ncia
    [SerializeField] float toTarget;

    // Chamado a cada frame
    void Update()
    {
        RaycastHit hit;

        // Realiza um Raycast (raio) a partir da posi��o do jogador na dire��o que ele est� olhando (frente)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            // Se o raio colidir com algum objeto, salva a dist�ncia at� o objeto atingido
            toTarget = hit.distance;

            // Atualiza a vari�vel est�tica com a dist�ncia para que outros scripts possam usar
            distanceFromTarget = toTarget;
        }
    }
}
