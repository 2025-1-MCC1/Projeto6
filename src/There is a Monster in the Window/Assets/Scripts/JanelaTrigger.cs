using UnityEngine;
using TMPro;
using System.Collections;

public class JanelaTrigger : MonoBehaviour
{
    public GameObject JanelaUI;
    public TextMeshProUGUI textoJanela;
    public string[] falasJanela;
    public float tempoEntreFalas = 1f;
    public float typeDelay = 0f;
    public Color corFala = Color.white;

    private bool falando = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !falando)
        {
            StartCoroutine(ExecutarDialogo());
        }
    }
    private IEnumerator ExecutarDialogo()
    {
        falando = true;
       JanelaUI.SetActive(true);

        foreach (string fala in falasJanela)
        {
            textoJanela.color = corFala;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }

        JanelaUI.SetActive(false);
        falando = false;
    }
    private IEnumerator DigitarTexto(string frase)
    {
        textoJanela.text = "";
        foreach (char letra in frase.ToCharArray())
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
