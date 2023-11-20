using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseMultiPowerUp : PowerUpScript
{
    public override void DoPowerup()
    {
        if (PlayerString == "Player1")
        {
            StartCoroutine(UIManager.Instance.PlayPowerupAnim(0, "Enemy x0.5", 0));
            StartCoroutine(DecreaseMultiplier(1));
        }
        else if (PlayerString == "Player2")
        {
            StartCoroutine(UIManager.Instance.PlayPowerupAnim(0, "Enemy x0.5", 1));
            StartCoroutine(DecreaseMultiplier(0));
        }
    }

    private IEnumerator DecreaseMultiplier(int index)
    {
        if (GameManager.Instance.ScoreMultiplier[index] !< 0.5f)
        {
            float currentScore = GameManager.Instance.ScoreMultiplier[index];
            GameManager.Instance.ScoreMultiplier[index] = 0.5f;
            yield return new WaitForSeconds(15);
            GameManager.Instance.ScoreMultiplier[index] = currentScore;
        }
    }
}
