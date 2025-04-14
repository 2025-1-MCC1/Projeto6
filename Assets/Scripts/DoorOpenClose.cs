using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    public Transform door;
    public GameObject interactUI;
    private bool isOpen = false;
    private bool canInteract = false;

    private void Start()
    {
        interactUI.SetActive(false);
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            ToggleDoor();
            interactUI.SetActive(false); // Hide UI after pressing E
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactUI.SetActive(false);
        }
    }

    private void ToggleDoor()
    {
        if (isOpen)
        {
            door.Rotate(0f, -90f, 0f);
            door.position = new Vector3(-8.486f, 0.8486315f, -6.842f);
        }
        else
        {
            door.Rotate(0f, 90f, 0f);
            door.position = new Vector3(-8.877f, 0.8486315f, -6.356f);
        }

        isOpen = !isOpen;
    }
}
