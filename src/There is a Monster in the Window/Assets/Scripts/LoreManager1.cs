using UnityEngine;
using UnityEngine.SceneManagement;
public class LoreManager1 : MonoBehaviour
{
    // Para contar a hist�ria
    public void StartStory()
    {
        SceneManager.LoadScene("LoreDois");
    }

    public void StartPlay()
    {
        SceneManager.LoadScene("cenaCasa");
    }

}




