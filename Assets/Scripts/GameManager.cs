using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1;

    [Header("Player 2")]
    public GameObject AI;

    [Header("Score UI")]
    public TMP_Text player1ScoreText;
    public TMP_Text AIScoreText;

    private int p1Score = 0;
    private int p2Score = 0;

    private void Start()
    {
        instance = this;
    }
    public void P1Scored()
    {
        p1Score++;
        player1ScoreText.text = p1Score.ToString();
    }

    public void P2Scored()
    {
        p2Score++;
        AIScoreText.text = p2Score.ToString();
    }
    public void ResetPosition()
    {
        ball.GetComponent<BallMovement>().Reset();
        player1.GetComponent<Movement>().Reset();
        AI.GetComponent<Movement>().Reset();
    }
}