using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMultiPowerUp : PowerUpScript
{
    public override void DoPowerup()
    {
        StartCoroutine(IncreaseMultiplier());
    }

    private IEnumerator IncreaseMultiplier()
    {
        int index = 0;
        switch (PlayerString)
        {
            case "Player1":
                index = 0;
                StartCoroutine(UIManager.Instance.PlayPowerupAnim(2, "Multi +1", 0));
                break;
            case "Player2":
                index = 1;
                StartCoroutine(UIManager.Instance.PlayPowerupAnim(2, "Multi +1", 1));
                break;
        }
        GameManager.Instance.ScoreMultiplier[index] += 1f;
        yield return new WaitForSeconds(15);
        GameManager.Instance.ScoreMultiplier[index] -= 1f;
    }
}
