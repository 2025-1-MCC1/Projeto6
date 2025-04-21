using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour
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
            animator.SetTrigger("Open1");
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
                animator.SetTrigger("Close1");
                //Debug.Log("Porta fechou");
            }
            colliding = false;
        }
    }
}   


