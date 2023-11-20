using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendGameTimePowerUp : PowerUpScript
{
    private void AddTime(float time)
    {
        GameManager.Instance.Timer += time;
        #if UNITY_EDITOR
        print("Time has been extended by: " + time);
        #endif
    }
    public override void DoPowerup()
    {
        if (PlayerString == "Player1")
        {
            StartCoroutine(UIManager.Instance.PlayPowerupAnim(1, "More Time!", 0));
        }
        else if (PlayerString == "Player2")
        {
            StartCoroutine(UIManager.Instance.PlayPowerupAnim(1, "More Time!", 1));
        }
        AddTime(15);
    }
}
