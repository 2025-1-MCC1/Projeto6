using UnityEngine;

public class GenericPickUp : MonoBehaviour
{
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 1.9f)
        {
            UIController.actionText = "Pegar Objeto";
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
