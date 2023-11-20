using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    [Space]
    public List<float> Score;
    public List<float> ScoreMultiplier;

    public string player1Highscore = "player1Highscore";
    public string player2Highscore = "player2Highscore";

    public float Timer;
    public float EndTime;

    public bool StartCountingScore = false;
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        Timer = 120f;
    }

    private void Update()
    {
        UIManager.Instance.Multi(ScoreMultiplier);
        if (StartCountingScore)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= EndTime)
        {
            Debug.Log("Setting active!");
            StartCoroutine(EndTimer());
        }
    }

    private IEnumerator EndTimer()
    {
        Time.timeScale = 0f;

        UIManager.Instance.EndMenuStart(true);
        GameManager.Instance.CheckHighscores();
        UIManager.Instance.SetScoresPlayers();
        yield return null;
    }

    void FixedUpdate()
    {
        //score adding based on time
        if (StartCountingScore)
        {
            Score[0] += IncreaseScore(1, ScoreMultiplier[0]);
            Score[1] += IncreaseScore(1, ScoreMultiplier[1]);
        }
        else
        {
            for (int i = 0; i < Score.Count; i++)
            {
                Score[i] = 0;
            }
        }
    }

    /// <summary>
    /// Multiplies the Multiplier by the score and returns the score that needs to be added
    /// </summary>
    /// <param name="ScoreAmount"></param>
    /// <param name="multi"></param>
    /// <returns></returns>
    public float IncreaseScore(float ScoreAmount, float multi)
    {
        ScoreAmount *= multi;
        return ScoreAmount;
    }

    public void CheckHighscores()
    {
        if (GetFloat(player1Highscore) <= Score[0])
        {
            SetFloat(player1Highscore, Score[0]);
        }

        if (GetFloat(player2Highscore) <= Score[1])
        {
            SetFloat(player2Highscore, Score[1]);
        }

    }

    public void SetFloat(string KeyName, float Value)
    {
        PlayerPrefs.SetFloat(KeyName, Value);
    }

    public float GetFloat(string KeyName)
    {
        return PlayerPrefs.GetFloat(KeyName);
    }
}
