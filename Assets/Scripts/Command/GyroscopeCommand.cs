using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeCommand : ICommand
{
    private Rigidbody2D rb;
    private float speed;

    public GyroscopeCommand(Rigidbody2D rb, float speed)
    {
        this.rb = rb;
        this.speed = speed;
    }

    public Vector2 Execute()
    {
        // Get the current tilt of the device using the gyroscope
        float tilt = Input.gyro.gravity.x;
        float tiltY = Input.gyro.gravity.y;
        return new Vector2(tilt, tiltY);

    }
}
