using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputActionReference interAction;
    public GameObject panel;
    private float lastToggleTime; //Pour eviter le spam de l'UI
    public bool isOpen;
    public DaySystem daySystem;
    public PlayerMovement playerMovement;



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


}
