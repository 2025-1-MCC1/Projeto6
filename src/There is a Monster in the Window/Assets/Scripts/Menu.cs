using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script simples de menu para iniciar o jogo
public class Menu : MonoBehaviour
{
    //public AudioSource clickAudio;

    // Função pública que pode ser chamada por um botão no menu para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena de índice 1 (definido na build settings do Unity)
        
        SceneManager.LoadScene("Lore");
    }

   
    public void Controls()
    {
        
        SceneManager.LoadScene("Controls");
    }
    
    public void BackToMenu()
    {
        
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
