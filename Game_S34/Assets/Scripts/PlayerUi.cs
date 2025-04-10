using UnityEngine;
using TMPro;


public class CameraControl : MonoBehaviour
{
    public TextMeshProUGUI textInteraction;
    public bool interactUi = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Trash") || collision.CompareTag("InteractUI"))
        {
            textInteraction.enabled = true;
            //show text 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash") || collision.CompareTag("InteractUI"))
        {
            textInteraction.enabled = false;
            //Unshow text 
        }

    }
}
