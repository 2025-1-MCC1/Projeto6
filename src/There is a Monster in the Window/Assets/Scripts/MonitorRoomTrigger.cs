using UnityEngine;
using TMPro;
using System.Collections;

public class MonitorRoomTrigger : MonoBehaviour
{
    public GameObject MonitorUI;
    public TextMeshProUGUI textoMonitores;
    public string[] falasMonitor;
    public float tempoEntreFalas = 1f;
    public float typeDelay = 0.01f;
    public Color corJogador = Color.white;

    private bool dialogoJaAconteceu = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogoJaAconteceu)
        {
            dialogoJaAconteceu = true;
            MonitorUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }
    private IEnumerator ExecutarDialogo()
    {
        foreach (string fala in falasMonitor)
        {
            textoMonitores.color = corJogador;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }
        MonitorUI.SetActive(false);
    }
    private IEnumerator DigitarTexto(string frase)
    {
        textoMonitores.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoMonitores.text += letra;
            yield return new WaitForSeconds(typeDelay);
        }
    }


    void Update()
    {
        
    }
}
