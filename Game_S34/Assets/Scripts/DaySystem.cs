using TMPro;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int dayCount = 1;
    public TextMeshProUGUI dayCountText;
    public TextMeshProUGUI hourCountText;
    public int trashObjective = 35;

    // Timer qui s'exécute, dès que le timer se fini un nouveau jour est lancé
    // Le timer est réglé sur 3 min le jour s'effectue sur 12 heure fictive (un rythme de 15sec pour une heure -> 15*12=180)

    public float targetTime = 180.0f;
    public float actualTime = 0f;

    public int heureCompteur = 0;
    public float heureActualTime = 0f; 

    public Animator fadeSystem;
    public bool onPauseMenu = false;

    private Transform playerSpawn;
    public Transform playerTransform;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void Update()
    {
        if (targetTime > actualTime && dayCount < 8 && onPauseMenu != true)
        {
            actualTime += Time.deltaTime;
            heureActualTime += Time.deltaTime;

            if (heureActualTime >= 15f)
            {
                Debug.Log("GOOG");
                heureCompteur++;
                heureActualTime = 0;

                hourCountText.text = (heureCompteur + 8).ToString() + ":00";
            }
        }
        else if (targetTime < actualTime)
        {
            fadeSystem.SetBool("FadeIn", true);
            fadeSystem.SetBool("FadeOut", false);
        }
        else
        {
            Debug.Log("Rémi est l'homme le plus chanceux de tout les temps...");
            Debug.Log("Fin du jeu");
        }
    }

    public void DayEnd()
    {
        // est appelé à la fin de la journée (/à la fin de l'aniamtion fadeOut)
        Debug.Log("One day has passed");

        dayCount++;
        actualTime = 0f;
        trashObjective = Mathf.RoundToInt(trashObjective + 45 * (0.1f * dayCount));
        dayCountText.text = "Jour " + dayCount.ToString();
        heureCompteur = 0;
        heureActualTime = 0f;

        playerTransform.position = playerSpawn.position; // Reset the player position
        Inventory.instance.TrashReset(); // Reset the trash count 

        fadeSystem.SetBool("FadeIn", false);
        fadeSystem.SetBool("FadeOut", true);
    }
}