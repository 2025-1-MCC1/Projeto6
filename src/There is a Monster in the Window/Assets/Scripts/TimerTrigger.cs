using UnityEngine;
using TMPro;
using System.Collections;

public class TimerTrigger : MonoBehaviour
{

    public GameObject balaoUI;
    public TextMeshProUGUI textoTimer;
    public string[] falas;
    public Color corTexto = Color.white;

    public Timer scriptDoTimer;

    private bool falou230 = false;
    private bool falou400 = false;


    void Start()
    {
        if (balaoUI != null)
            balaoUI.SetActive(false);
    }

    
    void Update()
    {
        int horas = Mathf.FloorToInt(scriptDoTimer.currentGameTimeInMinutes / 60f) % 24;
        int minutos = Mathf.FloorToInt(scriptDoTimer.currentGameTimeInMinutes % 60f);

        if (horas == 2 && minutos == 30 && !falou230)
        {
            falou230 = true;
            StartCoroutine(MostrarFalas(0)); // fala para 2h30
        }

        if (horas == 4 && minutos == 0 && !falou400)
        {
            falou400 = true;
            StartCoroutine(MostrarFalas(1)); // fala para 4h00
        }

    }

    private System.Collections.IEnumerator MostrarFalas(int index)
    {
        balaoUI.SetActive(true);
        textoTimer.color = corTexto;
        textoTimer.text = "";

        string frase = falas.Length > index ? falas[index] : "Algo aconteceu...";
        foreach (char letra in frase.ToCharArray())
        {
            textoTimer.text += letra;
            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(3f); // tempo na tela
        balaoUI.SetActive(false);
    }
}
