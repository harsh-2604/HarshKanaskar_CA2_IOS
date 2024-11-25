using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DisplayPlayerName : MonoBehaviour
{
    public TMP_Text usernameTextDisplay; 
    private string filePath;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";
        LoadAndDisplayUsername();
    }

    private void LoadAndDisplayUsername()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            if (playerData != null)
            {
                usernameTextDisplay.text = playerData.username;
            }
            else
            {
                Debug.LogWarning("No player data found in the file!");
                usernameTextDisplay.text = "No username found!";
            }
        }
        else
        {
            Debug.LogWarning("Player data file not found!");
            usernameTextDisplay.text = "No username found!";
        }
    }
}