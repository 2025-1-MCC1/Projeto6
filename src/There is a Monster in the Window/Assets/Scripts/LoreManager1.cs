using UnityEngine;
using UnityEngine.SceneManagement;
public class LoreManager1 : MonoBehaviour
{
    // Para contar a história
    public void StartStory()
    {
        SceneManager.LoadScene("LoreDois");
    }

    public void StartPlay()
    {
        SceneManager.LoadScene("cenaCasa");
    }

}




