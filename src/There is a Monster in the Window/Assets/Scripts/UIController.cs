using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Controlador de UI responsável por exibir ou ocultar elementos da interface durante a interação
public class UIController : MonoBehaviour
{
    // Variáveis estáticas que podem ser acessadas por outros scripts para definir o texto e ativar a UI
    public static string actionText;       // Texto que descreve a ação (ex: "Abrir porta")
    public static string commandText;      // Texto que descreve o comando (ex: "Interagir")
    public static bool uiActive;           // Flag que controla se a UI está ativa ou não

    // Referências aos elementos da interface no Inspector
    [SerializeField] GameObject actionBox;     // Caixa de texto que exibe a ação
    [SerializeField] GameObject commandBox;    // Caixa de texto que exibe o comando
    [SerializeField] GameObject interactCross; // Indicador visual de interação (ex: uma cruz no centro da tela)

    // Chamado uma vez por frame
    void Update()
    {
        // Se a UI estiver ativa, exibe os elementos e atualiza os textos
        if (uiActive == true)
        {
            actionBox.SetActive(true);
            commandBox.SetActive(true);
            interactCross.SetActive(true);

            // Atualiza os textos nas caixas com os valores definidos
            actionBox.GetComponent<TMPro.TMP_Text>().text = actionText;
            commandBox.GetComponent<TMPro.TMP_Text>().text = commandText;
        }
        else
        {
            // Caso contrário, oculta todos os elementos da interface
            actionBox.SetActive(false);
            commandBox.SetActive(false);
            interactCross.SetActive(false);
        }
    }
}
