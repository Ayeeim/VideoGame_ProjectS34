using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreenInfos : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("main_menu");//Changement de scene
        Debug.Log("Retour au menu principal");
    }
}
