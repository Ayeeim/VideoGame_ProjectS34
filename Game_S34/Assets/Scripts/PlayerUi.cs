using UnityEngine;
using TMPro;


public class CameraControl : MonoBehaviour
{
    public TextMeshProUGUI textInteraction;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enter");
            textInteraction.enabled = true; // affiche le texte PickUp

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
