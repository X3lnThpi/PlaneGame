using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommand : ICommand
{
    private Rigidbody2D rb;
    private float speed;
    private float turnAngle = 90f;
    private float playerAngle = 0f;
    private Vector2 playerPosition = Vector2.zero;
    public enum ButtonType { Left, Right };
    ButtonType buttonType;
    private Joystick joystick;

    public ButtonCommand(Rigidbody2D rb, float speed, Joystick joystick)
    {
        this.rb = rb;
        this.speed = speed;
        this.buttonType = buttonType;
        this.joystick = joystick;
    }

    void Update()
    {
        // Get input from the joystick
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // Calculate movement vector based on input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize movement vector to ensure consistent speed
        movement = movement.normalized * speed * Time.deltaTime;

        // Add movement to the rigidbody
        rb.AddForce(movement);
    }

    public Vector2 Execute()
    {
        // Get input from the joystick
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // Calculate and return movement vector
        return new Vector2(horizontalInput, verticalInput);


        //// Calculate the velocity based on the
        //// Calculate the velocity based on the button type
        //if (buttonType == ButtonType.Left)
        //{
        //    playerAngle -= turnAngle;
        //    playerPosition += new Vector2(Mathf.Cos(playerAngle), Mathf.Sin(playerAngle));
        //    return playerPosition;
        //    //return new Vector2(-speed, 0);
        //}
        //else
        //{
        //    playerAngle += turnAngle;
        //    playerPosition += new Vector2(Mathf.Cos(playerAngle), Mathf.Sin(playerAngle));
        //    return playerPosition;
        //    //return new Vector2(speed, 0);
        //}
    }
}
