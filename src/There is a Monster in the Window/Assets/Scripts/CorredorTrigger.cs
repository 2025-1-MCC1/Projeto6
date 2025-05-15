using UnityEngine;
using TMPro;
using System.Collections;

public class CorredorTrigger : MonoBehaviour
{
    public GameObject CorredorUI;
    public TextMeshProUGUI textoCorredor;
    public string[] falasCorredor;
    public float tempoEntreFalas = 1f;
    public float typeDelay = 0.01f;
    public Color corJogador = Color.white;

    private bool dialogoJaAconteceu = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogoJaAconteceu)
        {
            dialogoJaAconteceu = true;
            CorredorUI.SetActive(true);
            StartCoroutine(ExecutarDialogo());
        }
    }
    private IEnumerator ExecutarDialogo()
    {
        foreach (string fala in falasCorredor)
        {
            textoCorredor.color = corJogador;
            yield return StartCoroutine(DigitarTexto(fala));
            yield return new WaitForSeconds(tempoEntreFalas);
        }
        CorredorUI.SetActive(false);
    }
    private IEnumerator DigitarTexto(string frase)
    {
        textoCorredor.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoCorredor.text += letra;
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
