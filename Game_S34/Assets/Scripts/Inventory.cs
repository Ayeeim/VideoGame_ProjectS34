using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

    public int trashCount;

    public DaySystem daySystem;

    public static Inventory instance;
    public TextMeshProUGUI trashCountText;

    // Awake is called before the game starts
    private void Awake()
    {
        if(instance!=null)
        {
            // Check si il n'y a bien qu'un seul inventaire, sinon envoie le message d'erreur ci-dessous
            Debug.LogWarning("Il y a plus d'une instance de inventory dans la scène.");
            return;
        }

        trashCountText.text = "Déchets ramassé : " + trashCount.ToString() + " sur " + daySystem.trashObjective.ToString();

        instance = this;
    }

    // Update is called once per frame
    public void AddTrash(int _count)
    {
        trashCount += _count;
        trashCountText.text = "Déchets ramassé : " + trashCount.ToString() + " sur " + daySystem.trashObjective.ToString();
        Debug.Log("A trash has been added to the count");
    }

    public void TrashReset()
    {
        trashCount = 0;
        trashCountText.text = "Déchets ramassé : " + trashCount.ToString() + " sur " + daySystem.trashObjective.ToString();
        Debug.Log("Trash count has been reseted");
    }
}
