using UnityEngine;

public class flashlight : MonoBehaviour
{

    public GameObject ON;
    public GameObject OFF;
    private bool isON;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isON)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }
            if (!isON)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }

            isON = !isON;
        }
    }
}
