using UnityEngine;
using UnityEngine.InputSystem;

public class SaveSystem : MonoBehaviour
{
    public DaySystem daySystem;
    public string dayCountData;
    public InputActionReference interAction; //Bouton sauvegarde temporaire

    private void FixedUpdate()
    {
        if(interAction.action.IsPressed())
        {
            SaveToJson();
        }
    }
    public void SaveToJson()
    {
        SaveData data = new SaveData();
        data.dayCount = daySystem.dayCount;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/save.json";
        System.IO.File.WriteAllText(path, json);
        Debug.Log("Sauvegarde effectuée !");

    }
    public void LoadFromJSon()
    {
        string filePath = Application.persistentDataPath + "/dayCountData.json";
        string dayCountData = System.IO.File.ReadAllText(filePath);

        daySystem.dayCount = JsonUtility.FromJson<int>(dayCountData);
        Debug.Log("Chargement de la sauvegarde réussi");

    }
}

[System.Serializable]
public class SaveData
{
    public int dayCount;
}

