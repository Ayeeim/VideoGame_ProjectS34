using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{

    public InputActionReference interAction;
    public bool interactUi = false;


    private void Update()
    {
        if (interAction.action.IsPressed() && interactUi == true)
        {
            Debug.Log("Button has beeeeeeeen pressed");
            Destroy(gameObject);
            Inventory.instance.AddTrash(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enter");

            interactUi = true;
            // affiche le texte PickUp

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Exit");
            interactUi = false;
            //Unshow text 
        }

    }
}
