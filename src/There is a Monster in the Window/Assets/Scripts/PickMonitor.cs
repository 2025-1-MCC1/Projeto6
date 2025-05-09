using UnityEngine;

public class PickMonitor : MonoBehaviour
{
    public GameObject interactUI;
    private bool colliding;
    public GameObject monitorMao;

    void Start()
    {
        interactUI.SetActive(false);
        monitorMao.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && colliding)
        {
            interactUI.SetActive(true);
            Destroy(gameObject);
            interactUI.SetActive(false);
            UIController.uiActive = false;
            UIController.commandText = "";
            monitorMao.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
            UIController.actionText = "Pick Up Monitor";
            UIController.commandText = "[E] Pick Up";
            UIController.uiActive = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(false);
            UIController.uiActive = false;
            UIController.commandText = "";
            colliding = false;
        }
    }

}
