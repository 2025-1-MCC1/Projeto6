using System.Collections.Generic;
using UnityEngine;

public class SphereTest : MonoBehaviour
{
    void OnMouseOver()
    {
        if(PlayerCasting.distanceFromTarget < 1.9f)
        {
            UIController.actionText = "Pick up Sphere";
            UIController.commandText = "Pick up";
            UIController.uiActive = true;
        }
        
    }
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}
