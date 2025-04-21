using System;
using TMPro;
using UnityEngine;
using System.Collections;

public class DaySystem : MonoBehaviour
{
    public int dayCount = 0;
    public TextMeshProUGUI dayCountText;
    public int trashObjective = 45;

    // Timer qui s'exécute, dès que le timer se fini un nouveau jour est lancé
    // Le timer est réglé sur 3 min le jour s'effectue sur 12 heure fictive (un rythme de 15sec pour une heure -> 15*12=180)

    public float targetTime = 180.0f;
    public float actualTime = 0f;

    public Animator fadeSystem;
    public bool onPauseMenu = false;

    private void Update()
    {
        if (targetTime > actualTime && dayCount < 8 && onPauseMenu != true)
        {
            actualTime += Time.deltaTime;
        }
        else if (targetTime < actualTime)
        {
            Debug.Log("Idiot");
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
        Debug.Log("One day has passed");
        dayCount++;
        actualTime = 0f;
        trashObjective = Mathf.RoundToInt(trashObjective + 45 * (0.1f * dayCount));
        dayCountText.text = "Jour " + dayCount.ToString();
        fadeSystem.SetBool("FadeIn", false);
        fadeSystem.SetBool("FadeOut", true);
    }
}