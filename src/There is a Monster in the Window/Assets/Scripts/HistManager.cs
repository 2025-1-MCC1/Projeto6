using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HistoriaManager : MonoBehaviour
{
    [System.Serializable]
    public class Slide
    {
        public Sprite imagem;
        public string texto;
    }

    public List<Slide> slides; // Lista de pares imagem + texto
    public Image imagemDisplay; // Campo para arrastar o objeto de imagem (UI > Image)
    public TMP_Text textoDisplay; // Campo para arrastar o componente TextMeshPro
    public Button proximoBotao;
    public Button jogarBotao;

    private int slideAtual = 0;

    void Start()
    {
        MostrarSlide();
        jogarBotao.gameObject.SetActive(false); // Só aparece no final
    }

    public void ProximoSlide()
    {
        slideAtual++;
        if (slideAtual < slides.Count)
        {
            MostrarSlide();
        }
        else
        {
            proximoBotao.gameObject.SetActive(false);
            jogarBotao.gameObject.SetActive(true); // Ativa botão "Jogar"
        }
    }

    void MostrarSlide()
    {
        imagemDisplay.sprite = slides[slideAtual].imagem;
        textoDisplay.text = slides[slideAtual].texto;
    }

    public void Jogar()
    {
        SceneManager.LoadScene("NomeDaCenaDoJogo"); // Troque pelo nome da sua cena
    }
}