using UnityEngine;

public class CameraPickUp : MonoBehaviour
{
    public Light spotLight;
    public AudioSource alertSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ou "Intruder"
        {
            Debug.Log("Movimento detectado!");


            if (spotLight != null)
                spotLight.color = Color.red;

            if (alertSound != null)
                alertSound.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Área limpa.");


            if (spotLight != null)
                spotLight.color = Color.green;
        }
    }
}
