using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // The speed at which the player moves
    public float turnAngle = 45f;
    public Joystick joystick;

    private Rigidbody2D rb; // The player's Rigidbody component

    private ICommand currentCommand; // The currently active command

    // The Model for the player character
    public PlayerModel playerModel;

    // The view for the player character
    public PlayerView playerView;

    // The default values for the player's properties
    public PlayerDefaultValues defaultValues;

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = Vector2.zero; // The final velocity of the player

        // Check if the gyroscope input is enabled
        if (Input.gyro.enabled)
        {
            // Use the gyroscope command
            currentCommand = new GyroscopeCommand(rb, speed);
        }
        else if(!Input.gyro.enabled)
        {
            //Joystick COntrol
            currentCommand = new ButtonCommand(rb, speed, joystick);
        }

         // If no button is being pressed, use the default command
        else
        {
            currentCommand = new DefaultCommand(rb);
        }
        

        // Execute the current command and set the player's velocity
        rb.velocity = currentCommand.Execute();
    }
}
