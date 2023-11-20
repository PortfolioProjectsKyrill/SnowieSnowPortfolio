using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumpSomeScorePowerUp : PowerUpScript
{
    private void Update()
    {

    }
    public override void DoPowerup()
    {
        if (PlayerString == "Player1")
        {
            AddScoreAmount(500, 0);
        }
        else if (PlayerString == "Player2")
        {
            AddScoreAmount(500, 1);
        }
    }

    private void AddScoreAmount(int scoreAmount, int index)
    {
        StartCoroutine(UIManager.Instance.PlayPowerupAnim(2, "More Score!", index));
        GameManager.Instance.Score[index] += scoreAmount;
        StartCoroutine(UIManager.Instance.PlayScoreAnim(scoreAmount, index));
    }
}
