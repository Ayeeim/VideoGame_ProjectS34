using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SettingsInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputActionReference interAction;
    public GameObject panel;
    private float lastToggleTime; //Pour eviter le spam de l'UI
    public bool isOpen;
    public DaySystem daySystem;
    public PlayerMovement playerMovement;
    public SaveSystem saveSystem;



    private void FixedUpdate()
    {
        if(interAction.action.IsPressed() && Time.time - lastToggleTime > 0.3f)
        {
            if (!isOpen)
            {
                panel.SetActive(true);
                isOpen = true;
                daySystem.onPauseMenu = true;
                playerMovement.movementEnabled = false;
            } else
            {
                panel.SetActive(false);
                isOpen = false;
                daySystem.onPauseMenu = false;
                playerMovement.movementEnabled = true;
            }

            lastToggleTime = Time.time;
        }
    }

    public void quitMenu()
    {
        panel.SetActive(false);
        isOpen = false;
        daySystem.onPauseMenu = false;
        playerMovement.movementEnabled = true;
    }

    public void MainMenu()
    {
        saveSystem.SaveToJson();
        SceneManager.LoadScene("main_menu");//Changement de scene
        Debug.Log("Retour au menu principal");
    }


}
