using TMPro;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int dayCount = 1;
    public SaveSystem saveSystem;
    public TextMeshProUGUI dayCountText;
    public TextMeshProUGUI hourCountText;
    public int trashObjective = 35;

    // Timer qui s'exécute, dès que le timer se fini un nouveau jour est lancé
    // Le timer est réglé sur 3 min le jour s'effectue sur 12 heure fictive (un rythme de 15sec pour une heure -> 15*12=180)

    public float targetTime = 180.0f;
    public float actualTime = 0f;

    [SerializeField] private int heureCompteur = 0;
    public float heureActualTime = 0f; 

    public Animator fadeSystem;
    public bool onPauseMenu = false;

    private Transform playerSpawn;
    public Transform playerTransform;

    [SerializeField] private SpawnZoneTrash spawnZoneTrash;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        saveSystem.LoadFromJSon();
        dayCountText.text = "Jour " + dayCount.ToString();
    }

    private void Update()
    {
        if (targetTime > actualTime && dayCount <= 7 && onPauseMenu != true)
        {
            actualTime += Time.deltaTime;
            heureActualTime += Time.deltaTime;

            if (heureActualTime >= 15f)
            {
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
        trashObjective = Mathf.RoundToInt(trashObjective + 35 * (0.1f * dayCount));
        dayCountText.text = "Jour " + dayCount.ToString();

        // Reset les variables communes et les objets dans la scène
        actualTime = 0f;
        heureCompteur = 0;
        heureActualTime = 0f;
        playerTransform.position = playerSpawn.position; // Reset la position du joueur
        Inventory.instance.TrashReset();
        hourCountText.text = "8:00";
        spawnZoneTrash.spawnedTrash = 0;
        spawnZoneTrash.trashDestroy();


        // Aniamtion de fade In fade Out
        fadeSystem.SetBool("FadeIn", false);
        fadeSystem.SetBool("FadeOut", true);
    }
}