using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lives;
    public int health;
    public int currentLives;
    public SavePlayerTime savePlayerTime;
    void Update()
    {
        if(health > currentLives)
        {
            health = currentLives;
        }
        for (int i = 0; i < lives.Length; i++)
        {
            if(i < currentLives)
            {
                lives[i].SetActive(true);
            }
            else
            {
                lives[i].SetActive(false);
            }
        }
        if (health <= 0 && currentLives <= 0)
        {
            GameOver();
        }
    }
    public void ReduceHealth(int amount)
    {
        health -= amount;
        currentLives -= amount;
        currentLives = Mathf.Max(0, currentLives);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        savePlayerTime.SaveTime();
        SceneManager.LoadScene("Game Over");   
    }
}