using UnityEngine;
using UnityEngine.UI;

public class BarradeSanidade : MonoBehaviour
{
    // sistema de sanidade
    public int sanidade = 50;
    public int sanidadeMaxima = 100;
    public int sanidadeMinima = 0;
    public Slider barraSanidade;

    //fatores
    public bool estaDentroDaCasa = false;
    public bool monstroNaJanela = false;
    public bool janelaVazia = false;
    public bool ouvindoBarulhos = false;
    public bool semLuz = false;

    void Start()
    {
        barraSanidade.maxValue = sanidadeMaxima;
        barraSanidade.value = sanidade;
    }

    void Update()
    {
        if (estaDentroDaCasa)
        {
            int mudancaSanidade = 0;

            if (monstroNaJanela)
                mudancaSanidade -= 20;

            if (janelaVazia)
                mudancaSanidade -= 12;

            if (ouvindoBarulhos)
                mudancaSanidade -= 6;

            if (semLuz)
                mudancaSanidade -= 15;

            if (!monstroNaJanela && !janelaVazia && !ouvindoBarulhos && !semLuz)
                mudancaSanidade += 10  ; // se nenhum dos fatores acima estiver presente, ele recupera a sanidade

            AtualizarSanidade(mudancaSanidade);
        }
    }

    void AtualizarSanidade(int quantidade) // fica entre 0 e 100
    {
        sanidade += quantidade;
        sanidade = Mathf.Clamp(sanidade, 0, sanidadeMaxima);
        barraSanidade.value = sanidade;
    }

    public void EntrarNaCasa()
    {
        estaDentroDaCasa = true;
    }

    public void SairDaCasa()
    {
        estaDentroDaCasa = false;
    }
}