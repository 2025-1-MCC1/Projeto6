using UnityEngine;

public class MotionDetector : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ou "Intruder"
        {
            Debug.Log("Movimento detectado!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Área limpa.");
        }
    }
}
