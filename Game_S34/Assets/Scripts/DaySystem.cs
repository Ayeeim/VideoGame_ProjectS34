using System;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public float dayCount = 1f;
    public int trashObjective = 45;

    // Timer qui s'exécute, dès que le timer se fini un nouveau jour est lancé
    // Le timer est réglé sur 3 min le jour s'effectue sur 12 heure fictive (un rythme de 15sec pour une heure -> 15*12=180)

    public float targetTime = 180.0f;
    public float actualTime = 0f;
    public bool onPauseMenu = false;

    private void Update()
    {
        if (targetTime > actualTime && dayCount < 7 && onPauseMenu != true)
        {
            actualTime += Time.deltaTime;
        }
        else if(targetTime <= actualTime) 
        {  
            dayEnd();
        }
        else
        {
            Debug.Log("Rémi est l'homme le plus chanceux de tout les temps...");
            Debug.Log("Fin du jeu");
        }
    }

    private void dayEnd()
    {
        Debug.Log("One day has passed");
        actualTime = 0f;
        dayCount++;
        trashObjective = Mathf.RoundToInt(trashObjective + trashObjective*(0.1f *  dayCount));
        // Une sauvegarde automatique peut être effectué ici (juste besoin d'appeler de script de save)
    }
}
