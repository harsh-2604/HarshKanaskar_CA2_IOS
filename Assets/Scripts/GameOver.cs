using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1.0f;
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
