using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class EnterUsername : MonoBehaviour
{
    public TMP_Text usernameText;
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";
    }

    public void SaveUsername()
    {
        string username = usernameText.text;
        if (string.IsNullOrEmpty(username))
        {
            Debug.LogWarning("Username cannot be blank!");
            return;
        }
        PlayerData playerData = new PlayerData { username = username };
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filePath, json);
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Username saved to JSON: " + username);
    }
}

[System.Serializable]
public class PlayerData
{
    public string username;
    public float timePlayed;
}
