using UnityEngine;
using TMPro;
using System.Collections;

public class EscadaDialogo : MonoBehaviour
{
    public GameObject EscadaUI;
    public TextMeshProUGUI textoEscada;
    public string[] falasJogador;
    public float tempoEntreFalas = 1f;
    public float typeDelay = 0.005f;
    public Color corJogador = Color.white;

    private bool jaFalou = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !jaFalou)
        {
            jaFalou = true;
            EscadaUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }

    private IEnumerator ExecutarDialogo()
    {
        foreach (string fala in falasJogador)
        {
            textoEscada.color = corJogador;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }

        EscadaUI.SetActive(false);
    }

    private IEnumerator DigitarTexto(string frase)
    {
        textoEscada.text = "";
        foreach (char letra in frase)
        {
            textoEscada.text += letra;
            yield return new WaitForSeconds(typeDelay);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
