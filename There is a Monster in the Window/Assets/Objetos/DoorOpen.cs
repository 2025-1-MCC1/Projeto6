using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorOpen : MonoBehaviour
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
            animator.SetTrigger("Open");
            interactUI.SetActive(true);
            //Debug.Log("Porta abriu");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
            UIController.commandText = "Open";
            UIController.uiActive = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doorOpen)
            {
                animator.SetTrigger("Close");
               
                //Debug.Log("Porta fechou");
            }
            interactUI.SetActive(false);
            UIController.uiActive = true;
            UIController.commandText = "";
            colliding = false;
        }
    }
}   


