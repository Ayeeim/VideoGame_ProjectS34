using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{

    public bool interactUi = false;

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
        Debug.Log("t");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enter");
            interactUi = true;
            //Canvas.PickUp.text 
            //Show text 
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
            interactUi = false;
            //Unshow text 
        }

    }
}
