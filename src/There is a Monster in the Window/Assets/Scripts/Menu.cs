using UnityEngine;
using UnityEngine.SceneManagement;

// Script simples de menu para iniciar o jogo
public class Menu : MonoBehaviour
{
    // Fun��o p�blica que pode ser chamada por um bot�o no menu para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena de �ndice 1 (definido na build settings do Unity)
        SceneManager.LoadScene(1);
    }
}
