using UnityEngine;
using UnityEngine.SceneManagement; // <-- Adicionamos isso aqui de novo para usar SceneManager

public class KeepAudioPlaying : MonoBehaviour
{
    private int cenaOndeDestruir = 4; 

    
    void Awake()
    {
       
        DontDestroyOnLoad(this.gameObject);

        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        Debug.Log($"Cena carregada: {scene.name}"); // Cena atual

        if (scene.buildIndex == cenaOndeDestruir)
        {
            Debug.Log($" '{cenaOndeDestruir}' Destruindo audio"); // Para ver no console
            
            Destroy(this.gameObject);
        }
    }
}