using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{

    private bool interactUi = false;

    void Awake()
    {
        
    }

    private void Update()
    {
        if (interactUi == true && Input.GetKey(KeyCode.E))
        {
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
        }


        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("TTTT2");
            interactUi = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       Debug.Log("t2");
    
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Exit");
        }

    }
}
