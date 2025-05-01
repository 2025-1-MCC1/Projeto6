using UnityEngine;

// Script que simula uma câmera de segurança detectando o jogador
public class CameraPickUp : MonoBehaviour
{
    // Referência à luz da câmera (pode mudar de cor para indicar alerta)
    public Light spotLight;

    // Referência ao som de alerta que será tocado quando algo for detectado
    public AudioSource alertSound;

    // Chamado automaticamente quando outro objeto com collider entra no trigger desta câmera
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou tem a tag "Player"
        if (other.CompareTag("Player")) // Pode ser alterado para "Intruder" se necessário
        {
            Debug.Log("Movimento detectado!");

            // Se houver uma luz associada, muda a cor para vermelho (alerta)
            if (spotLight != null)
                spotLight.color = Color.red;

            // Se houver um som de alerta configurado, ele é reproduzido
            if (alertSound != null)
                alertSound.Play();
        }
    }

    // Chamado automaticamente quando o objeto com collider sai do trigger desta câmera
    void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Área limpa.");

            // Muda a cor da luz de volta para verde (estado normal)
            if (spotLight != null)
                spotLight.color = Color.green;
        }
    }
}
