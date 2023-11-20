using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeScoreIncreasePowerUp : PowerUpScript
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(UIManager.Instance.PlayPowerupAnim(4, "Overtime Score", 0));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(UIManager.Instance.PlayPowerupAnim(4, "Overtime Score", 1));
        }
    }
    public override void DoPowerup()
    {
        StartCoroutine(OverTimeScoreIncrease());
    }
    IEnumerator OverTimeScoreIncrease()
    {
        if (PlayerString == "Player1")
        {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.Score[0] += 100;//score werkt
                StartCoroutine(UIManager.Instance.PlayScoreAnim(100, 0));
                if (i != 5)
                    yield return new WaitForSeconds(1.5f);
            }
        }
        else if (PlayerString == "Player2")
        {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.Score[1] += 100;
                StartCoroutine(UIManager.Instance.PlayScoreAnim(100, 1));
                if (i != 5)
                    yield return new WaitForSeconds(1.5f);
            }
        }
    }

}
