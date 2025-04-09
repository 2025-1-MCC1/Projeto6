using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorClosed;
    public GameObject DoorOpen;
    public GameObject interactcrossHair;
    public float openTime; 

    private void OnTriggerStay(Collider other) //player olhando pra porta vai ativar o trigger
    {
        if (other.CompareTag("MainCamera"))
        {
            interactcrossHair.SetActive(true); //vai aparecer a crosshair pra apertar o E
            if(Input.GetKeyDown(KeyCode.E))
            {
                interactcrossHair.SetActive(false); // vai desligar o crosshair
                DoorClosed.SetActive(false); // vai desativar o gameobject DoorClosed
                DoorOpen.SetActive(true) ; // vai ativar o gameobject DoorOpen
                StartCoroutine(closeDoor()); // a thread pra fechar a porta

            }
        }

    }

    IEnumerator closeDoor()
    {
        yield return new WaitForSeconds(openTime);
        DoorOpen.SetActive(false);
        DoorClosed.SetActive(true); //desativa o Open e ativa o Closed
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("MainCamera"))
        {
            interactcrossHair.SetActive(false);
        }
    }
}
