using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class DoublePlayerInput : MonoBehaviour
{
    private float i_movement;
    public float speed = 10;
    private float horizontalSpeed = 7;
    private Rigidbody rb;

    public GameObject cam;
    public Vector3 cameraMovement;
    public Vector3 player;

    private int stopPlayers = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);
        speed = 0;

        //The player gets added to a list of all players
        PlayerInputManagerSystem.instance.players.Add(gameObject);
    }

    private void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(6, 6);
        
        MovePlayer();
        //the camera will move when player collides with an obstacle
        cameraMovement = cam.transform.position;
    }

    private void MovePlayer()
    {
        //The transform of the player
        player = transform.position;
        //The input from the gamepad will be set with a speed to the sides accordingly to the deltaTime
        player.x += + i_movement * horizontalSpeed * Time.deltaTime;
        //The x position is also set between 2 axies so limit the player inside the bounds of the game
        player.x = Mathf.Clamp(player.x, -3.6f, 0.4f);
        player.z += speed * Time.deltaTime;

        //Send a raycast down to check how far down you are
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            //Sets the player a small bit above the ground to that the player is always close to the ground
            player.y = hit.point.y +0.06f; 
        }

        //The player will be set to the position calculated for the player
        transform.position = player;
    }

    /// <summary> 
    /// The Function where the player gets the inputs from the controler and will be set accordingly
    /// </summary>
    /// <param name="value"></This parameter gives the intut from the controlers in the type InputValue and is set to an vector2 to get the corresponding coordinates>
    private void OnMove(InputValue value)
    {        
        i_movement = value.Get<Vector2>().x;
    }
}
