using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputActionReference interAction;
    public GameObject panel;
    private float lastToggleTime; //Pour eviter le spam de l'UI
    public bool isOpen;


    private void FixedUpdate()
    {
        if(interAction.action.IsPressed() && Time.time - lastToggleTime > 0.3f)
        {
            if (!isOpen)
            {
                panel.SetActive(true);
                isOpen = true;
            } else
            {
                panel.SetActive(false);
                isOpen = false;
            }

            lastToggleTime = Time.time;
        }
    }


}
