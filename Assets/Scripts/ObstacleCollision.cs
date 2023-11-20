using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = collision.gameObject;
        player.GetComponent<DoublePlayerInput>().speed = 0;
        Time.timeScale = 0;
        StartCoroutine(EndTimer(0, collision.gameObject));
    }

    private IEnumerator EndTimer(float seconds, GameObject player)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0f;

        UIManager.Instance.EndMenuStart(true);
        GameManager.Instance.CheckHighscores();
        UIManager.Instance.SetScoresPlayers();
        UIManager.Instance.CheckWhatPlayerCrashed(player);

        yield return null;
    }
}
