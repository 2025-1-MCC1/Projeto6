using UnityEngine;
using UnityEngine.SceneManagement;

// Script simples de menu para iniciar o jogo
public class Menu : MonoBehaviour
{
    // Função pública que pode ser chamada por um botão no menu para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena de índice 1 (definido na build settings do Unity)
        SceneManager.LoadScene(1);
    }
}
