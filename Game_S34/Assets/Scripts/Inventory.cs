using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int triangleCount;

    public static Inventory instance;

    // Awake is called before the game starts
    private void Awake()
    {
        if(instance!=null)
        {
            // Check si il n'y a bien qu'un seul inventaire, sinon envoie le message d'erreur ci-dessous
            Debug.LogWarning("Il y a plus d'une instance de inventory dans la scène.");
            return;
        }

        instance= this;
    }

    // Update is called once per frame
    public void AddTrash(int count)
    {
        triangleCount += count;
        Debug.Log("A trash has been added to the count");
    }
}
