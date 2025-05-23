using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class MonsterBehavior : MonoBehaviour
{
    public Transform dest1, dest2, dest3, dest4, dest5;
    private Transform[] destinations;

    public ItemSwitcher itemSwitcher;
    public Transform player;

    public float timeDelay = 40f;
    public float firstSpawn = 240f;

    public float detectionDistance = 5f;
    public bool monsterHiding = true;

    public Vector3 hideLocation = new Vector3(0, -1000, 0);

    public GameObject interactUI;

    public AudioSource teleportAudio; //som do teleporte
    //public AudioSource hideAudio;� � //som de quando aperta F



    void Start()
    {
        destinations = new Transform[] { dest1, dest2, dest3, dest4, dest5 };
        transform.position = hideLocation;

        
        teleportAudio = GetComponent<AudioSource>();
        //hideAudio = GetComponent<AudioSource>();
      

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
        Debug.Log("Primeira apari��o");
        StartCoroutine(DelayMonsterSpawn());
    }
    private void OnMouseOver()
    {
        if (itemSwitcher.activeItem == 1 && Vector3.Distance(transform.position, player.position) < detectionDistance)
        {
            UIController.uiActive = true;
            UIController.actionText = "Ativar caixa";
            UIController.commandText = "[F] Ativar";

            if (Input.GetKeyDown(KeyCode.F))
            {
                //hideAudio.Play();
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
       // hideAudio.Play();
        //StartCoroutine(AudioEnding());
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

   /* IEnumerator AudioEnding()
    {
        yield return new WaitUntil(() => hideAudio.isPlaying);
    }*/

}
