using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class MonsterBehavior : MonoBehaviour
{
    public Transform dest1, dest2, dest3, dest4;
    private Transform[] destinations;

    public ItemSwitcher itemSwitcher;


    public Transform player;

    public float timeDelay = 10f;

    public float detectionDistance = 5f;
    private bool monsterHiding = true;

    public Vector3 hideLocation = new Vector3(0, -1000, 0);

    public GameObject interactUI;


    void Start()
    {

        transform.position = hideLocation;
        destinations = new Transform[] { dest1, dest2, dest3, dest4 };

        StartCoroutine(DelayMonsterSpawn());

    }

    void Update()
    {

    }

    IEnumerator DelayMonsterSpawn()
    {
        yield return new WaitForSeconds(timeDelay);

        Debug.Log("Monstro se teleportou");
        IsActive();

        OnMouseOver();

        
    }
    private void OnMouseOver()
    {
        if (itemSwitcher.activeItem == 1 && Vector3.Distance(transform.position, player.position) < detectionDistance)
        {
            UIController.uiActive = true;
            UIController.actionText = "Activate spiritbox";
            UIController.commandText = "[F] Activate";

            if (Input.GetKeyDown(KeyCode.F))
            {
                UIController.actionText = "";
                UIController.commandText = "";
                UIController.uiActive = false;

                ReturnHiding();
            }
        }
    }

    private void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }

    private void ReturnHiding()
    {
        monsterHiding = true;
        transform.position = hideLocation;
        StartCoroutine(DelayMonsterSpawn());
    }
    private void IsActive()
    {
        monsterHiding = false;
        int index = Random.Range(0, destinations.Length);
        Transform chosenDest = destinations[index];
        transform.position = chosenDest.position;
        transform.rotation = chosenDest.rotation;


    }



}


