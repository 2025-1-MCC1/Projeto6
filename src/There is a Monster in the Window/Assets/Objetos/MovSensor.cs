using System.Collections.Generic;
using UnityEngine;

public class MovSensor : MonoBehaviour
{
    void OnMouseOver()
    {
        if(PlayerCasting.distanceFromTarget < 1.9f)
        {
            UIController.actionText = "Pegar Sensor de Mov.";
            UIController.commandText = "[E] Pegar";
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
