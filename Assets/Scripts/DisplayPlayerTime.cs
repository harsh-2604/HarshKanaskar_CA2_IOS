using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DisplayPlayerTime : MonoBehaviour
{
    public TMP_Text timeText; 
    private string filePath;
    private void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";
        LoadPlayerTime();
    }

    private void LoadPlayerTime()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            if (playerData != null)
            {
                float timePlayed = playerData.timePlayed;
                DisplayTime(timePlayed);
            }
            else
            {
                Debug.LogWarning("No player data found in the file!");
                timeText.text = "Time: 00:00";
            }
        }
        else
        {
            Debug.LogWarning("Player data file not found!");
            timeText.text = "Time: 00:00";
        }
    }

    private void DisplayTime(float timePlayed)
    {
        timeText.text = TimeFormat(timePlayed);
    }

    private string TimeFormat(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}