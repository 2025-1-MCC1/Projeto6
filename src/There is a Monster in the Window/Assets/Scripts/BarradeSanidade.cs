using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BarraDeSanidade : MonoBehaviour
{
    private float health;
    private float lerpTimer;// contador de tempo 
    public float sanidadeMaxima = 100f; //máximo de sanidade do jogador
    public float sanidadeAtual = 30; // começa o jogo com 30 de sanidade
    public float chipSpeed = 2f; // define quanto tempo (em segundos) deve demorar para completar a transição da barra
    private float tempoParaRecuperar = 5f; // o jogador recupera de 5 em 5
    private float tempoRecuperando = 0f;
    private float lastSanidade = 30f;

    public Image frontHealthBar;
    public Image backHealthBar;

    // controle dos fatores que alteram a sanidade
    private bool viuRadio = false;
    private bool detectouMonstro = false;
    private bool geradorQuebrado = false;


    void Start()
    {
        sanidadeAtual = 30f;
        lastSanidade = sanidadeAtual;
        AtualizarBarraInstantaneo();
    }


    void Update()
    {
        AtualizarBarraInstantaneo(); 

        if (sanidadeAtual != lastSanidade)
        {
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            backHealthBar.fillAmount = Mathf.Lerp(backHealthBar.fillAmount, sanidadeAtual / sanidadeMaxima, percentComplete);

            if (lerpTimer >= chipSpeed)
            {
                frontHealthBar.fillAmount = sanidadeAtual / sanidadeMaxima;
                lastSanidade = sanidadeAtual;
                lerpTimer = 0f;
            }
        }
        // recupera sanidade se nada estiver acontecendo
        if (!viuRadio && !detectouMonstro && !geradorQuebrado && sanidadeAtual < sanidadeMaxima)
        {
            tempoRecuperando += Time.deltaTime;
            if (tempoRecuperando >= tempoParaRecuperar)
            {
                AlterarSanidade(5);
                tempoRecuperando = 0f;
            }
        }
        else
        {
            tempoRecuperando = 0f;
        }
    }
    public void MonstroDetectado()
    {
        detectouMonstro = true;
        sanidadeAtual -= 20;
        Debug.Log("Sanidade caiu por detectar o monstro. Valor atual: " + sanidadeAtual);
        Invoke(nameof(ResetDetector), 3f); // reseta depois de 3 segundos
    }

    public void EntrarNaCasa() 
    {
        sanidadeAtual = 50;
        AtualizarBarraInstantaneo();
    }

    public void VerRadio() // o jogador perde sanidade
    {
        if (!viuRadio)
        {
            viuRadio = true;
            Debug.Log("Viu o rádio: ");
            AlterarSanidade(-25);
        }
    }
    public void GeradorQuebrou() // o jogador perde 15 de sanidade
    {
        AlterarSanidade(-15);
        geradorQuebrado = true;
    }

    public void GeradorConsertado()
    {
        geradorQuebrado = false;
    }

    void ResetDetector()
    {
        detectouMonstro = false;
    }

    void AlterarSanidade(int valor)
    {
        sanidadeAtual += valor;
        sanidadeAtual = Mathf.Clamp(sanidadeAtual, 0, sanidadeMaxima); // agora sim
        lerpTimer = 0f; // reinicia o timer para animar a barra
        AtualizarBarraInstantaneo();
    }
    void AtualizarBarraInstantaneo() // atualiza o visual da imagem para perda e ganho de sanidade
    {
        float frenteFill = frontHealthBar.fillAmount;
        float alvo = sanidadeAtual / sanidadeMaxima;

        if (frenteFill < alvo)
        {
            frontHealthBar.fillAmount = Mathf.Lerp(frenteFill, alvo, Time.deltaTime * chipSpeed);
            backHealthBar.fillAmount = alvo;
            backHealthBar.color = Color.green;
        }
        else if (frenteFill > alvo)
        {
            frontHealthBar.fillAmount = alvo;
            backHealthBar.fillAmount = Mathf.Lerp(backHealthBar.fillAmount, alvo, Time.deltaTime * chipSpeed);
            backHealthBar.color = Color.red;
        }
    }
    
}