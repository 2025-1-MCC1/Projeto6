using UnityEngine;

public class ItemSwitcher : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject spiritBox;

    public int activeItem = 0; //index para cada item na mão
    void Start()
    {
        // Garante que a lanterna esteja ativada e a Spirit_Box desativada ao iniciar o jogo
        flashlight.SetActive(true);
        spiritBox.SetActive(false);
        activeItem = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            flashlight.SetActive(true);
            spiritBox.SetActive(false);
            activeItem = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            flashlight.SetActive(false);
            spiritBox.SetActive(true);
            activeItem = 1;
        }
    }
}
