using UnityEngine;

public class ItemSwitcher : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject spiritBox;

    void Start()
    {
        // Garante que a lanterna esteja ativada e a Spirit_Box desativada ao iniciar o jogo
        flashlight.SetActive(true);
        spiritBox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            flashlight.SetActive(true);
            spiritBox.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            flashlight.SetActive(false);
            spiritBox.SetActive(true);
        }
    }
}
