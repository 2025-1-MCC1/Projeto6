using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BarraDeSanidade : MonoBehaviour
{
    private float health;
    private float lerpTimer;// contador de tempo 
    public float sanidadeMaxima = 100f; //máximo de sanidade do jogador
    public float sanidadeAtual = 50; // começa o jogo com 50 de sanidade
    public float chipSpeed = 2f; // define quanto tempo (em segundos) deve demorar para completar a transição da barra
    private float tempoParaRecuperar = 20f; // o jogador recupera de 5 em 5
    private float tempoRecuperando = 6f;
    private float lastSanidade = 30f;
    public Color corAlta = Color.green; // sanidade boa
    public Color corMedia = Color.yellow; // sanidade média
    public Color corBaixa = Color.red; //sanidade baixa
    public Image backHealthBar;
    private bool piscando = false; // efeito piscando 
    private Coroutine efeitoPiscar;

    //controle dos fatores que alteram a sanidade
    private bool viuRadio = false;
    private bool detectouMonstro = false;
    private bool geradorQuebrado = false;
    void Start()
    {
        if (sanidadeAtual < 30.1f) // só define 50 se estiver ainda no valor inicial
        {
            sanidadeAtual = 50f;
        }
        lastSanidade = sanidadeAtual;
        backHealthBar.fillAmount = sanidadeAtual / sanidadeMaxima;
        lerpTimer = chipSpeed; // não pisca
    }

    void Update()
    {
        {
            float porcentagem = sanidadeAtual / sanidadeMaxima;

            if (sanidadeAtual != lastSanidade)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / chipSpeed;
                backHealthBar.fillAmount = Mathf.Lerp(backHealthBar.fillAmount, sanidadeAtual / sanidadeMaxima, percentComplete);

                if (lerpTimer >= chipSpeed)
                {
                    lastSanidade = sanidadeAtual;
                    lerpTimer = 0f;
                }
            }

            if (porcentagem >= 0.5f) // 50% ou mais  verde, sem piscar
            {
                if (piscando)
                {
                    piscando = false;
                    if (efeitoPiscar != null)
                        StopCoroutine(efeitoPiscar);
                    backHealthBar.color = corAlta;
                    backHealthBar.enabled = true; // garante visibilidade
                }
                else
                {
                    backHealthBar.color = corAlta;
                }
            }
            else if (porcentagem >= 0.25f) // entre 25% e 50% - amarelo, sem piscar
            {
                if (piscando)
                {
                    piscando = false;
                    if (efeitoPiscar != null)
                        StopCoroutine(efeitoPiscar);
                    backHealthBar.color = corMedia;
                    backHealthBar.enabled = true;
                }
                else
                {
                    backHealthBar.color = corMedia;
                }
            }
            else // abaixo de 25% - vermelho, piscando
            {
                if (!piscando)
                {
                    piscando = true;
                    efeitoPiscar = StartCoroutine(PiscarBarra());
                }
            }

            // Recuperação da sanidade (se quiser mantém seu código)
            if (!viuRadio && !detectouMonstro && !geradorQuebrado && sanidadeAtual < sanidadeMaxima)
            {
                tempoRecuperando += Time.deltaTime;
                if (tempoRecuperando >= tempoParaRecuperar)
                {
                    tempoRecuperando = 0f;
                }
            }
            else
            {
                tempoRecuperando = 0f;
            }
        }

    }
    public void MonstroDetectado()
    {
        detectouMonstro = true;
        sanidadeAtual -= 20;
        Debug.Log("Sanidade caiu por detectar o monstro. Valor atual: " + sanidadeAtual);
        Invoke(nameof(ResetDetector), 3f); //reseta depois de 3 segundos
    }


    public void VerRadio() // o jogador perde sanidade
    {
        if (!viuRadio)
        {
            viuRadio = true;
            AlterarSanidade(-10);
            Invoke(nameof(ResetViuRadio), 10f);
        }
    }
    void ResetViuRadio()
    {
        viuRadio = false;
    }
    public void GeradorQuebrou() // o jogador perde 25 de sanidade
    {
        if (geradorQuebrado) return;
        AlterarSanidade(-25);
        geradorQuebrado = true;
    }

    public void GeradorConsertado()
    {
        if (!geradorQuebrado) return;
        geradorQuebrado = false;
    }

    void ResetDetector()
    {
        detectouMonstro = false;
    }

    void AlterarSanidade(int valor)
    {
        if (geradorQuebrado && valor > 0) return;
        sanidadeAtual += valor;
        sanidadeAtual = Mathf.Clamp(sanidadeAtual, 0, sanidadeMaxima);
        lerpTimer = 0f; // reinicia o timer para animar a barra
    }
    void AtualizarBarraInstantaneo() // atualiza o visual da imagem para perda e ganho de sanidade
    {
        backHealthBar.fillAmount = sanidadeAtual / sanidadeMaxima;
    }
    IEnumerator PiscarBarra() // para a barra piscar
    {
        Color baseColor = corBaixa;

        while (piscando)
        {
            for (float t = 0; t <= 1; t += Time.deltaTime * 5)
            {
                Color c = baseColor;
                c.a = Mathf.Lerp(1f, 0.3f, t);
                backHealthBar.color = c;
                yield return null;
            }

            for (float t = 0; t <= 1; t += Time.deltaTime * 5)
            {
                Color c = baseColor;
                c.a = Mathf.Lerp(0.3f, 1f, t);
                backHealthBar.color = c;
                yield return null;
            }
        }

        baseColor.a = 1f;
        backHealthBar.color = baseColor;
    }
}
