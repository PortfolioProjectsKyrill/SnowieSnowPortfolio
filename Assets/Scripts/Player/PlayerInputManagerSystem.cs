using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerSystem : MonoBehaviour
{
    public static PlayerInputManagerSystem instance;

    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject startTimer;
    [SerializeField] private GameObject infoText;

    public List<GameObject> players;
    private int stopPlayers = 0;
    private int starting = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        //if there are 2 players in the game the game will start using a coroutine
        if (players.Count == 2 && starting == 0)
        {
            starting++;
            StartCoroutine(StartTheGame());
        } //When the first player enters the game the first camera will be deactivated
        else if (players.Count == 1)
        {
            camera.SetActive(false);
        }
    }

    private IEnumerator StartTheGame()
    {
        //The info text will be deactivated
        infoText.SetActive(false);
        //The correct tags will be given to the players that are connected
        players[0].tag = "Player1";
        players[0].gameObject.GetComponentInChildren<GetPlayerData>().P1.SetActive(true);
        players[1].tag = "Player2";
        players[1].gameObject.GetComponentInChildren<GetPlayerData>().P2.SetActive(true);
        //The GameObject with an animation will be set to active to start the countdown timer to start the game
        startTimer.SetActive(true);
        startTimer.GetComponent<Animator>().SetTrigger("start timer");
        //The 3 seconds will be waited to start the game
        yield return new WaitForSeconds(3f);

        //The timer will start and will also start counting the score
        GameManager.Instance.StartCountingScore = true;

        //All the players thier speed will be set active so that the players can race again
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<DoublePlayerInput>().speed = 10;
        }
        //The coutndown timer object will disapear to remove the countdown timer
        startTimer.SetActive(false);

        yield return null;
    }

    void OnPlayerJoined(PlayerInput input)
    {
        if (input.user.id == 1)
        {
            print(input.gameObject);
            input.gameObject.transform.position = new Vector3 (-2.6f, 1, 0);
            input.gameObject.GetComponentInChildren<GetPlayerData>().P1.SetActive(true);
        }
        else if (input.user.id == 2)
        {
            print(input.gameObject);
            input.gameObject.transform.position = new Vector3(-0.6f, 1, 0);
            input.gameObject.GetComponentInChildren<GetPlayerData>().P2.SetActive(true);
        }
    }
}