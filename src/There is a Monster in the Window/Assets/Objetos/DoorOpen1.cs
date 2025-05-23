using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour
{
    public GameObject interactUI;
    public Animator animator;
    private bool colliding;
    private bool doorOpen = false;

    void Start()
    {
        interactUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && colliding)
        {
            doorOpen = true;
            animator.SetTrigger("Open1");
            interactUI.SetActive(true);
            //Debug.Log("Porta abriu");
        }
    }
    private void OnTriggerStay(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
            UIController.actionText = "Open Door";
            UIController.commandText = "[E] Open";
            UIController.uiActive = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doorOpen)
            {
                animator.SetTrigger("Close1");
                //Debug.Log("Porta fechou");
            }
            interactUI.SetActive(false);
            UIController.uiActive = false;
            UIController.commandText = "";
            colliding = false;
        }
    }
}   


