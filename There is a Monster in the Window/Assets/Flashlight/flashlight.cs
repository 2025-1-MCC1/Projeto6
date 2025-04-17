using UnityEngine;

// Script que permite ligar e desligar uma lanterna com a tecla F
public class flashlight : MonoBehaviour
{
    // GameObject que representa a lanterna ligada
    public GameObject ON;

    // GameObject que representa a lanterna desligada
    public GameObject OFF;

    // Flag que indica se a lanterna está ligada ou não
    private bool isON;

    // Chamado uma vez ao iniciar o script
    void Start()
    {
        // Inicia com a lanterna desligada
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;
    }

    // Chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla F foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isON)
            {
                // Se estiver ligada, desliga
                ON.SetActive(false);
                OFF.SetActive(true);
            }
            if (!isON)
            {
                // Se estiver desligada, liga
                ON.SetActive(true);
                OFF.SetActive(false);
            }

            // Inverte o estado da lanterna
            isON = !isON;
        }
    }
}
