using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using static UnityEngine.Rendering.DebugUI;

public class BarraDeSanidade : MonoBehaviour
{
    private float health;
    private float lerpTimer;// contador de tempo 
    public float maxHealth = 100f; //máximo de sanidade do jogador
    public float chipSpeed = 2f; // define quanto tempo (em segundos) deve demorar para completar a transição da barra
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;

    // fatores da sanidade
    public float monstroJanela = 20f;
    public float barulhos = 6f;
    public float faltaDeLuz = 15f;
    public float ganhoSanidade = 10f;

    // controle dos fatores que alteram a sanidade
    private bool dentroDaCasa = false;
    private float tempoVerificacao = 1f;
    private float tempoAtual = 0f;

    // Referências aos objetos do jogo
    public GameObject Criaturas;
    public GameObject[] Ventanas; // janelas da casa
    //public Light luzAmbiente; // a luz principal do ambiente, ainda nao feito
    //public float intensidadeMinima = 0.2f; // abaixo disso considera "escuro"
    //public bool somTocado = false; //ao escutar passos, barulho diminui a sanidade. colocar dps

    void Start()
    {
        health = 30f; //inicia o jogo com 30 de sanidade por estar na rua
    }


    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth); // sanidade inicial, mínima e máxima 
        UpdateHealthUI();

        if (dentroDaCasa)
        {
            tempoAtual += Time.deltaTime;
            if (tempoAtual >= tempoVerificacao)
            {
                VerificarFatores();
                tempoAtual = 0f;
            }
        }
    }
    void VerificarFatores()
    {
        bool algoAfetando = false;

        // Monstro na janela
        if (Criaturas.activeInHierarchy && EstaNaJanela(Criaturas.transform.position))
        {
            Debug.Log("Monstro está na janela: ");
            TakeDamage(monstroJanela);
            algoAfetando = true;
        }

        /* barulho
        if (somTocado)
        {
            TakeDamage(barulhos);
            somTocado = false; // reseta para não repetir até novo som
            algoAfetando = true;
        }*/

        /* falta de luz
        if (luzAmbiente != null && luzAmbiente.intensity < intensidadeMinima)
        {
            TakeDamage(faltaDeLuz);
            algoAfetando = true;
        }*/
        if (!algoAfetando)
        {
            RestoreHealth(ganhoSanidade);
        }

    } 
        bool EstaNaJanela(Vector3 posicaoCriaturas)
        {
            foreach (GameObject Ventanas in Ventanas)
            {
                if (Vector3.Distance(Ventanas.transform.position, posicaoCriaturas) < 2f) // ajusta o raio
                    return true;
            }
            return false;
        }
    

    public void EntrarNaCasa(bool status)
    {
        dentroDaCasa = status;
        if (status)
            health = 50f;
    }




    public void UpdateHealthUI()
    {
        Debug.Log("Sanidade atual: " + health);

        float hFraction = health / maxHealth;
        frontHealthBar.fillAmount = hFraction;
        backHealthBar.fillAmount = hFraction;


        


    }

    public void TakeDamage(float damage) // dano na sanidade do jogador 
    {
        Debug.Log("Perdeu Sanidade: " + damage);
        health -= damage; // afeta a sanidade
        lerpTimer = 0f;
    }
    public void RestoreHealth(float healAmount) // para restaurar a sanidade 
    {
        health += healAmount;
        lerpTimer = 0f;
    }
  }