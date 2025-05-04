using UnityEngine;
using System.Collections;


public class MonsterBehavior : MonoBehaviour
{
    public Transform dest1, dest2, dest3;
    private Transform[] destinations;

    public ItemSwitcher itemSwitcher;

    public Transform player;

    public Transform lookCenter;


    public float timeDelay = 10f;

    public float detectionDistance = 5f;
    private bool monsterHiding = true;

    public Vector3 hideLocation = new Vector3(0, -1000, 0);
    
    void Start()
    {
        
        transform.position = hideLocation;
        destinations = new Transform[] { dest1, dest2, dest3 };
        
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

        yield return new WaitUntil(() => itemSwitcher.activeItem == 1  && Vector3.Distance(transform.position, player.position) < detectionDistance);
        UIController.actionText = "Activate spiritbox";
        UIController.commandText = "Activate";
        UIController.uiActive = true;

       
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        UIController.uiActive = false;
        ReturnHiding();


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
        LookAtTarget();

    }

    void LookAtTarget()
    {
        transform.LookAt(lookCenter);
    }

}



