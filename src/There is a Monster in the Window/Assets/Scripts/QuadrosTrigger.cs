using UnityEngine;
using TMPro;
using System.Collections;

public class QuadrosTrigger : MonoBehaviour
{
    public GameObject QuadroUI;
    public TextMeshProUGUI textoQuadros;
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
            QuadroUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }
    private IEnumerator ExecutarDialogo()
    {
        foreach (string fala in falasJogador)
        {
            textoQuadros.color = corJogador;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }

        QuadroUI.SetActive(false);
    }
    private IEnumerator DigitarTexto(string frase)
    {
        textoQuadros.text = "";
        foreach (char letra in frase)
        {
            textoQuadros.text += letra;
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
