using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TagInteraction : MonoBehaviour
{
    [SerializeField] private bool isInRange; // Verifier qu'on est au bon endroit
    [SerializeField] private InputActionReference interAction;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float timeToClean;

    [SerializeField] private SpriteRenderer cabane;
    [SerializeField] private Sprite cabaneClean;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private IEnumerator CleanTag() //Permet de bloquer le personnage un certain temps
    {
        playerMovement.movementEnabled = false;
        Debug.Log("Nettoyage de la cabane");
        yield return new WaitForSeconds(timeToClean);
        cabane.sprite = cabaneClean;
        eventManager.isTag = false;
        playerMovement.movementEnabled = true;
    }

    private void FixedUpdate()
    {
        if(isInRange && interAction.action.IsPressed() && eventManager.isTag && inventory.activeItem == "brosse")
        {
            if (inventory.activeItem != "brosse")
            {
                Debug.Log("Vous n'avez pas de brosse");
            }
            StartCoroutine(CleanTag());
        }
        
    }

}
