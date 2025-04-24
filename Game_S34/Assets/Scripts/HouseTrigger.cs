using UnityEngine;
using UnityEngine.InputSystem;

public class HouseTrigger : MonoBehaviour
{
    public GameObject panel; //L'affichage du menu
    private float lastToggleTime; //Pour eviter le spam de l'UI
    public bool isInRange; // Verifier qu'on est au bon endroit
    public bool isHouseInventoryOpen; // Verifier si l'inventaire est ouvert ou non


    public InputActionReference interAction;
    public PlayerMovement playerMovement;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }



    void FixedUpdate()
    {
        if (isInRange && interAction.action.IsPressed() && Time.time - lastToggleTime > 0.3f)
        {
            if(isHouseInventoryOpen)
            {
                isHouseInventoryOpen = false;
                panel.SetActive(false);
                playerMovement.movementEnabled = true; // On peut deplacer le joueur

            }
            else
            {
                isHouseInventoryOpen = true;
                panel.SetActive(true);
                playerMovement.movementEnabled = false; // On ne peut pas deplacer le joueur
            }
            lastToggleTime = Time.time;

        }
    }


}



