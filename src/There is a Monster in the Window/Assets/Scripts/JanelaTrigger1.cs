using TMPro;
using UnityEngine;
using System.Collections;

public class JanelaTrigger1 : MonoBehaviour
{
    public GameObject JanelaUI;
    public TextMeshProUGUI textoJanela;
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
            JanelaUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }
    private IEnumerator ExecutarDialogo()
    {
        foreach (string fala in falasJogador)
        {
            textoJanela.color = corJogador;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }

        JanelaUI.SetActive(false);
    }
    private IEnumerator DigitarTexto(string frase)
    {
        textoJanela.text = "";
        foreach (char letra in frase)
        {
            textoJanela.text += letra;
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
