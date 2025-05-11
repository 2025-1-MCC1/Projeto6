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
    public float firstSpawn = 120f;

    public float detectionDistance = 5f;
    private bool monsterHiding = true;

    public Vector3 hideLocation = new Vector3(0, -1000, 0);

    public GameObject interactUI;

    public AudioSource teleportAudio; //som do teleporte
    public AudioSource hideAudio;    //som de quando aperta F



    void Start()
    {
        destinations = new Transform[] { dest1, dest2, dest3, dest4 };
        transform.position = hideLocation;

        
        teleportAudio = GetComponent<AudioSource>();
        hideAudio = GetComponent<AudioSource>();
      

        StartCoroutine(FirstTimeSpawn());



    }

    void Update()
    {

    }

    IEnumerator DelayMonsterSpawn()
    {
        yield return new WaitForSeconds(timeDelay);

        Debug.Log("Monstro se teleportou");
        IsActive();
        teleportAudio.Play();

        OnMouseOver();


    }

    IEnumerator FirstTimeSpawn()
    {
        yield return new WaitForSeconds(firstSpawn);
        Debug.Log("Primeira aparição");
        StartCoroutine(DelayMonsterSpawn());
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

                hideAudio.Play();
                
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
