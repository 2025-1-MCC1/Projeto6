using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using UnityEngine.SceneManagement;


public class BarraDeSanidade : MonoBehaviour
{
  
    [SerializeField] private float sanidadeMaxima = 100f; 
  
    [SerializeField] private float chipSpeed = 2f; 

    public Image backHealthBar; 

    [SerializeField] private float sanidadeAtual = 70f;
    private float lerpTimer; 
    private float lastSanidade = 30f; 

    public MonsterBehavior monsterBehavior; 
 
    public PowerEnergy geradorQuebrado;   

 
    [SerializeField] private float taxaPerdaSanidadeMonstro = 2f; // Quanto perde por segundo quando o monstro NÃO está hiding
    [SerializeField] private float taxaRecuperacaoSanidadeGeradorOk = 2f; // Quanto recupera por segundo quando o gerador NÃO está quebrado
    [SerializeField] private float taxaPerdaSanidadeGeradorQuebrado = 4f; // Quanto perde por segundo quando o gerador ESTÁ quebrado
    

    void Awake()
    {
      
        lastSanidade = sanidadeAtual;
      
        backHealthBar.fillAmount = sanidadeAtual / sanidadeMaxima;
          
        backHealthBar.color = Color.red;
    

        lerpTimer = 0f; 

      
    }

    
    void Start()
    {
        
    }

    void Update()
    {
      

        // Calcula a porcentagem da sanidade 
        float porcentagem = sanidadeAtual / sanidadeMaxima;

        
        if (sanidadeAtual != lastSanidade)
        {
            lerpTimer += Time.deltaTime;
            
            float percentComplete = lerpTimer / chipSpeed;

            backHealthBar.fillAmount = Mathf.Lerp(backHealthBar.fillAmount, porcentagem, percentComplete);
          


           
            if (lerpTimer >= chipSpeed)
            {
                backHealthBar.fillAmount = porcentagem;

                lastSanidade = sanidadeAtual;
               
                lerpTimer = 0f; 
            }
        }
   
     
        if (monsterBehavior != null && geradorQuebrado != null) 
        {
            float mudancaSanidadeNesteFrame = 0f; 
            
            if (geradorQuebrado.geradorQuebrado) // Se o gerador ESTÁ quebrado
            {
                mudancaSanidadeNesteFrame -= taxaPerdaSanidadeGeradorQuebrado * Time.deltaTime;
                
            }
            else // Se o gerador ESTÁ funcionando
            {
                mudancaSanidadeNesteFrame += taxaRecuperacaoSanidadeGeradorOk * Time.deltaTime; 
                                                                                                
            }

            
            if (!monsterBehavior.monsterHiding) // Se o monstro NÃO ESTÁ escondido
            {
                mudancaSanidadeNesteFrame -= taxaPerdaSanidadeMonstro * Time.deltaTime; 
                
            }

            if (mudancaSanidadeNesteFrame != 0f)
            {
                AlterarSanidade(mudancaSanidadeNesteFrame);
                
            }
        }
     
    }

    public void AlterarSanidade(float valor) 
    {
        sanidadeAtual += valor; 
        
        sanidadeAtual = Mathf.Clamp(sanidadeAtual, 0, sanidadeMaxima);

        lerpTimer = 0f;

        if (sanidadeAtual <= 0 )
        {
            SceneManager.LoadScene("YouDied");
        }
    
    }

   

}