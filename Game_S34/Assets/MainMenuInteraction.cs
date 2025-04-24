using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuInteraction : MonoBehaviour
{
    public GameObject panel;
    public SaveSystem saveSystem;
    public Button btnPlay;

    private void Awake()
    {
        string filePath = Application.persistentDataPath + "/save.json";
        if (System.IO.File.Exists(filePath))
        {
            btnPlay.interactable = true;
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");

#if UNITY_EDITOR
        // Si on est dans l'éditeur Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si on est dans un build (PC, Android, etc.)
        Application.Quit();
#endif
    }

    public void newSave()
    {
        saveSystem.ResetSave();
        SceneManager.LoadScene("map");//Changement de scene
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("map");//Changement de scene
    }
}