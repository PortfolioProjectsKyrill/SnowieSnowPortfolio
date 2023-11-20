using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public List<TextMeshProUGUI> ScoreText;

    public List<GameObject> ScoreAnim;

    public List<TextMeshProUGUI> ScoreAnimText;

    public List<TextMeshProUGUI> MultiText;

    [HideInInspector] public string PlayerStringUI;

    public TextMeshProUGUI TimerText;

    #region end menu
    [SerializeField] private GameObject ednmenu;
    [SerializeField] private TextMeshProUGUI leftScore;
    [SerializeField] private TextMeshProUGUI rightScore;
    [SerializeField] private TextMeshProUGUI leftHighScore;
    [SerializeField] private TextMeshProUGUI rightHighScore;
    #endregion

    [Header("Powerups")]
    [Space]
    public List<Sprite> PowerupSprites;

    public List<GameObject> SpriteAnimations;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        TimerText.text = string.Empty;
    }

    void Update()
    {
        PrintToScoreText();
        if (GameManager.Instance.StartCountingScore)
        {
            TimerText.text = GameManager.Instance.Timer.ToString("F0");
        }
    }

    /// <summary>
    /// Prints the score to the scoretext without the commas
    /// </summary>
    private void PrintToScoreText()
    {
        //zet de score naar de string die geprint word
        ScoreText[0].text = GameManager.Instance.Score[0].ToString("F0");
        ScoreText[1].text = GameManager.Instance.Score[1].ToString("F0");
    }

    /// <summary>
    /// plays score adding animations
    /// </summary>
    /// <param name="score"></param>
    /// <param name="PlayerNumber"></param>
    /// <returns></returns>
    public IEnumerator PlayScoreAnim(int score, int PlayerNumber)
    {
        GameObject jes = null;
        ScoreAnimText[PlayerNumber].text = "+ " + score.ToString();
        jes = Instantiate(ScoreAnim[PlayerNumber], gameObject.transform);
        yield return new WaitForSeconds(1.1f);
        jes.SetActive(false);
    }

    /// <summary>
    /// plays the powerup animation on screen
    /// </summary>
    /// <param name="SpritesIndex"></param>
    /// <param name="PowerupName"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public IEnumerator PlayPowerupAnim(int SpritesIndex, string PowerupName, int player)
    {
        GameObject anim = null;
        anim = Instantiate(SpriteAnimations[player], gameObject.transform);
        anim.GetComponentInChildren<Image>().sprite = PowerupSprites[SpritesIndex];//sprite of the image set to sprite in the list
        anim.GetComponentInChildren<TextMeshProUGUI>().text = PowerupName;//name set to parameter name
        yield return new WaitForSeconds(3);//wait till dissapearing
        anim.SetActive(false);
        //needs objectpool implementation
    }

    /// <summary>
    /// Sets the Multiplier text to the multiplier managed in the GameManager
    /// </summary>
    /// <param name="Multiplier"></param>
    public void Multi(List<float> Multiplier)
    {
        MultiText[0].text = "x" + Multiplier[0].ToString();
        MultiText[1].text = "x" + Multiplier[1].ToString();
    }
    public void EndMenuStart(bool active)
    {
        ednmenu.SetActive(active);
    }

    public void CheckWhatPlayerCrashed(GameObject player)
    {
        if (player.tag is "Player1")
        {
            leftScore.text = "Crashed!";
        }
        else if (player.tag is "Player2")
        {
            rightScore.text = "Crashed!";
        }
    }

    public void SetScoresPlayers()
    {
        leftScore.text = "Your Score: " + GameManager.Instance.Score[0].ToString();
        rightScore.text = "Your Score: " + GameManager.Instance.Score[1].ToString();
        leftHighScore.text = "Highscore: " + GameManager.Instance.GetFloat(GameManager.Instance.player1Highscore).ToString();
        rightHighScore.text = "Highscore: " + GameManager.Instance.GetFloat(GameManager.Instance.player2Highscore).ToString();
    }
}