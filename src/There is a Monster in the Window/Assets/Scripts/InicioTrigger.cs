using UnityEngine;
using TMPro;
using System.Collections;

public class InicioTrigger : MonoBehaviour
{
    public GameObject InicioUI;
    public TextMeshProUGUI textoInicio;
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
            InicioUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }
    private IEnumerator ExecutarDialogo()
    {
        foreach (string fala in falasJogador)
        {
            textoInicio.color = corJogador;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }

        InicioUI.SetActive(false);
    }
    private IEnumerator DigitarTexto(string frase)
    {
        textoInicio.text = "";
        foreach (char letra in frase)
        {
            textoInicio.text += letra;
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
