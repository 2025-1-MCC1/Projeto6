using UnityEngine;

// Script para um sensor de movimento que detecta quando o jogador entra ou sai de uma �rea
public class MotionDetectorCameras : MonoBehaviour
{
    public bool spotted = false;

    // Luz que ser� usada como indicador visual (ex: refletor do sensor)
    public Light spotLight;

    // Som de alerta que ser� reproduzido quando algo for detectado
    public AudioSource alertSound;

    // Chamado quando outro collider entra na �rea do sensor (trigger)
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea tem a tag "Player"
        if (other.CompareTag("Monster")) // Pode ser trocado por "Intruder" se necess�rio
        {
            Debug.Log("Movimento detectado!");

            spotted = true;

            // Muda a cor da luz para vermelho indicando alerta
            if (spotLight != null)
                spotLight.color = Color.red;

            // Reproduz o som de alerta
            if (alertSound != null)
                alertSound.Play();
        }
    }

    // Chamado quando o collider sai da �rea do sensor
    void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu da �rea tem a tag "Player"
        if (other.CompareTag("Monster"))
        {
            Debug.Log("�rea limpa.");

            spotted = false;

            // Muda a cor da luz de volta para verde (normalidade)
            if (spotLight != null)
                spotLight.color = Color.green;
        }
    }
}
