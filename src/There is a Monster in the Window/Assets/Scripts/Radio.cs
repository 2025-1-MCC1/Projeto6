using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class Radio : MonoBehaviour
{
    public GameObject RadioUI;
    public TextMeshProUGUI textoDialogo;      
    public string[] falasRadio;           
    public string[] falasJogador;              
    public float tempoEntreFalas = 1f;// Tempo entre cada fala completa
    public float typeDelay = 0.005f;// Tempo entre cada letra
    public Color corRadio = Color.green;
    public Color corPlayer = Color.white;     

    private bool dialogoIniciado = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogoIniciado)
        {
            dialogoIniciado = true;
            RadioUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }

    private IEnumerator ExecutarDialogo()
    {
        RadioUI.SetActive(true);

        // Falas do r�dio
        foreach (string fala in falasRadio)
        {
            textoDialogo.color = corRadio;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }
        // Falas do jogador
        foreach (string fala in falasJogador)
        {
            textoDialogo.color = corPlayer;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }

        RadioUI.SetActive(false);
    }
    private IEnumerator DigitarTexto(string frase) 
    {
        textoDialogo.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoDialogo.text += letra;
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