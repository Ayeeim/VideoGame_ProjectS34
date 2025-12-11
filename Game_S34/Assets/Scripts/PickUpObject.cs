using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{

    public InputActionReference interAction;
    public bool interactUi = false;


    private void Update()
    {
        if (interAction.action.IsPressed() && interactUi == true)
        {
            Destroy(gameObject);
            Inventory.instance.AddTrash(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUi = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUi = false;
        }

    }
}
