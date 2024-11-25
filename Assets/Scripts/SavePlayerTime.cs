using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePlayerTime : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";
    }

    public void SaveTime()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            if (playerData != null)
            {
                playerData.timePlayed = TimeManager.Instance.GetElapsedTime();
                string updatedJson = JsonUtility.ToJson(playerData, true);
                File.WriteAllText(filePath, updatedJson);

                Debug.Log("Player time saved: " + playerData.timePlayed + " seconds");
            }
            else
            {
                Debug.LogWarning("No valid player data found in the file!");
            }
        }
        else
        {
            Debug.LogWarning("Player data file not found! Creating new file.");

            PlayerData newPlayerData = new PlayerData
            {
                username = "DefaultPlayer", 
                timePlayed = TimeManager.Instance.GetElapsedTime()
            };
            string newJson = JsonUtility.ToJson(newPlayerData, true);
            File.WriteAllText(filePath, newJson);

            Debug.Log("New player data file created with time: " + newPlayerData.timePlayed + " seconds");
        }
    }
}