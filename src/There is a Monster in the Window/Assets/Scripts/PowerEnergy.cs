using System.Collections.Generic;
using UnityEngine;

public class PowerEnergy : MonoBehaviour
{ // Script de fazer as luzes quebrarem quando o gerador de energia quebrar
    public float vidaGerador = 90f; //vida do gerador, acaba em 90 seg da vida real (1min e meio)
    public float tempoSegurando = 0f; //quantos segundos o jogador ESTÁ segurando a tecla, aumenta essa variável 
    public float tempoParaReparo = 10f; //tempo em segundos que o jogador deve segurar a tecla E para valer 
    GameObject[] precisaLuz; //ARRAY para guardar QUAIS são os objetos que tem a tag que especifiquei (lights), dentro disso fica as luzes, as cameras de segurança e os sensores 
    public bool geradorQuebrado = false; //essa variável serve para sabermos que o gerador JÁ QUEBROU, para não desligar as luzes toda hora

    public Transform Jogador; //lugar do player na cena, serve para ver se o jogador está perto do fusivel
    public float distanciaParaSegurar = 1.5f; //distancia necessária para o jogador estar do fusivel

    private Dictionary<Camera, RenderTexture> cameraTextures = new Dictionary<Camera, RenderTexture>(); //dicionario para guardar o valor das cameras e a render texture delas

    void Start()
    {
        //Para capturar todas as luzes que existem na casa e guardar em um Vector
        precisaLuz = GameObject.FindGameObjectsWithTag("Light"); //coloca todos os objetos que tiverem a tag light dentro do array de Focos, guardando eles

    }

    // Aqui farei o gerador de energia quebrar quando a vida dele chegar no 0f, as luzes cairem e a função de apertar para consertar
    void Update()
    {
        //Vida do Gerador cair, e as luzes apagarem
      
        if (!geradorQuebrado) //se o gerador NAO estiver quebrado, a vida diminui com os frames
        {
            vidaGerador -= Time.deltaTime;


            if (vidaGerador <= 0f) //quando a vida chegar no 0, chama o void de desligar as luzes e deixa a variavel geradorQuebrado como verdadeira
            {
                Debug.Log("O gerador de energia quebrou!");
                vidaGerador = 0f;
                geradorQuebrado = true;
                DesligarLuzes();

            }
        }

        float distancia = Vector3.Distance(Jogador.position, transform.position); //para calcular a distancia que o player está do gerador, ver depois o raycast!!!


        if (geradorQuebrado && distancia <= distanciaParaSegurar)
        {
            
            if (Input.GetKey(KeyCode.E))
            {

                tempoSegurando += Time.deltaTime; //conta quantos segundos o tempo segurando está subindo, de acordo com os frames (Deltatime)
                Debug.Log("Tempo acumulado: " + tempoSegurando.ToString("F2") + " / " + tempoParaReparo);

                if (tempoSegurando >= tempoParaReparo)
                {
                    Debug.Log(">> CHAMANDO REPARO AGORA");
                    ConsertarGerador(); //chama o void de consertar o gerador SOMENTE se a tecla E foi pressionada por 10 segundos
                    tempoSegurando = 0f; // reseta após conserto
                    

                }
            }
            else
            {
                tempoSegurando = 0f; //se soltar a tecla, zera o tempo segurando -> gerador não conserta

            }
        }
        else
        {
            tempoSegurando = 0f; // só zera se sair da área
        }
        
    }

    void DesligarLuzes() //pega todos os objetos do array de precisaLuz e desliga, tambem pega a renderer da camera
    {


        foreach (GameObject foco in precisaLuz)
        {
            Light componente = foco.GetComponentInChildren<Light>();
            if (componente != null)
            {
                componente.enabled = false;
            }


            Camera camera = foco.GetComponentInChildren<Camera>();
            if (camera != null)
            {
                RenderTexture rt = camera.targetTexture;

                if (rt != null)
                {
                    if (!cameraTextures.ContainsKey(camera))
                    {
                        cameraTextures.Add(camera, rt); // salva a RenderTexture original
                    }


                    LimparRenderTexture(rt); //  Limpa o conteúdo da tela do monitor
                    camera.targetTexture = null;
                }

                camera.enabled = false;
                
            }
        }
    }
    void LimparRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture ativa = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.black);
        RenderTexture.active = ativa;
      
    }


   

    void LigarLuzes() //void de ligar luzes usando foreach game object set active, com os objetos do array de focos
    {
        foreach (GameObject foco in precisaLuz)
        {
            Light componente = foco.GetComponentInChildren<Light>();
            if (componente != null)
            {
                componente.enabled = true;
            }
            Camera camera = foco.GetComponentInChildren<Camera>();
            if (camera != null)
            {
                camera.enabled = true;
                if (cameraTextures.ContainsKey(camera))
                {
                    camera.targetTexture = cameraTextures[camera]; // restaurar a render texture
                }

            }

        }
       

    }

    void ConsertarGerador() //void de consertar
    {
        vidaGerador = 90f; //se o player segurou a tecla por 10 seg, a vida do gerador volta pra 90f
        tempoSegurando = 0f;
        geradorQuebrado = false; //marca que não está mais quebrado e chama o void de luzes ligadas
        LigarLuzes();
        Debug.Log("Gerador reparado!");

    }

}

//set active para as luzes
//raycast para os fusiveis - onde o jogador olhar, ele funciona
/**/