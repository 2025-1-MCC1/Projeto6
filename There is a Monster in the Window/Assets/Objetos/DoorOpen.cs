using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    private bool colliding;
    private bool doorOpen = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && colliding)
        {
            doorOpen = true;
            animator.SetTrigger("Open");
            //Debug.Log("Porta abriu");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
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
            colliding = false;
        }
    }
}   


