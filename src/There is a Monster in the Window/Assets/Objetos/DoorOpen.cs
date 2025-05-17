using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject interactUI;
    public Animator animator;
    
    private bool colliding;
    private bool doorOpen = false;

    public AudioSource openAudio;
    public AudioSource closeAudio;

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
            openAudio.Play();
            //Debug.Log("Porta abriu");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
            UIController.actionText = "Abrir porta";
            UIController.commandText = "[E] Abrir";
            UIController.uiActive = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doorOpen == true)
            {
                animator.SetTrigger("Close");
                closeAudio.Play();
                //Debug.Log("Porta fechou");
            }
            interactUI.SetActive(false);
            UIController.uiActive = false;
            UIController.commandText = "";
            colliding = false;
        }
    }
    
}   


