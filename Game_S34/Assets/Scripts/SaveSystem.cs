using UnityEngine;
using UnityEngine.InputSystem;

public class SaveSystem : MonoBehaviour
{
    public DaySystem daySystem;
    public InputActionReference saveAction; //Bouton sauvegarde temporaire
    public InputActionReference loadAction;
    public InputActionReference resetAction;
    private float lastToggleTime; //Pour eviter le spam
    public PlayerMission playerMission;

    private void FixedUpdate()
    {
        if (Time.time - lastToggleTime > 0.3f)
        {
            if (saveAction.action.IsPressed())
            {
                SaveToJson();
            }
            if (loadAction.action.IsPressed())
            {
                LoadFromJSon();
            }
            if (resetAction.action.IsPressed())
            {
                ResetSave();
            }
            lastToggleTime = Time.time;
        }
    }
    public void SaveToJson()
    {
        SaveData data = new SaveData();
        data.dayCount = daySystem.dayCount;
        data.currentChaos = playerMission.currentChaos;
        data.minChaos = playerMission.minChaos;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/save.json";
        System.IO.File.WriteAllText(path, json);
        Debug.Log("Sauvegarde effectuée !");
        Debug.Log(path);

    }
    public void LoadFromJSon()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            int dayCount = data.dayCount;
            daySystem.dayCount = dayCount;
            playerMission.currentChaos = data.currentChaos;
            playerMission.minChaos= data.minChaos;
            Debug.Log("Chargement effectuée");
        } else
        {
            Debug.Log("Aucune donnée de sauvegarde");
            SaveToJson();
        }
        daySystem.dayCountText.text = "Jour " + daySystem.dayCount.ToString();


    }

    public void ResetSave()
    {
        string filePath = Application.persistentDataPath + "/save.json";

        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            Debug.Log("Fichier de sauvegarde supprimé.");
        }
        else
        {
            Debug.Log("Aucun fichier de sauvegarde à supprimer");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int dayCount;
    public int minChaos;
    public int currentChaos;
}

