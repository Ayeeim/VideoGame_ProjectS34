using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpObject : MonoBehaviour
{

    public bool interactUi = false;

    public TextMeshProUGUI textPickUp;

    private void Update()
    {
        if (interactUi == true && Input.GetKey(KeyCode.E))
        {
            Destroy(gameObject);
            Debug.Log("Works");
            Inventory.instance.AddTrash(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enter");
            textPickUp.gameObject.SetActive(true); // affiche le texte PickUp
            interactUi = true;

        }

            if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("TTTT2");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       Debug.Log("t2");
    
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Exit");
            textPickUp.gameObject.SetActive(false);
            interactUi = false;
            //Unshow text 
        }

    }
}
