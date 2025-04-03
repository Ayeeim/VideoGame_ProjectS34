using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{

    public InputActionReference interAction;

    public bool interactUi = false;
    public TextMeshProUGUI textInteraction;

    private void Awake()
    {
        textInteraction = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        interAction.action.started += onInterActionStarted;
        interAction.action.Enable();

    }

    private void OnDisable()
    {
        interAction.action.started -= onInterActionStarted;
        interAction.action.Disable();
    }

    private void onInterActionStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("E has been pressed");
        Destroy(gameObject);
        Debug.Log("Works");
        Inventory.instance.AddTrash(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enter");
            textInteraction.enabled = true; // affiche le texte PickUp

            interactUi = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {    
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Exit");
            textInteraction.enabled = false;

            interactUi = false;
            //Unshow text 
        }

    }
}
