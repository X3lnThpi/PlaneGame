using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCommand : ICommand
{
    private Rigidbody2D rb;

    public DefaultCommand(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public Vector2 Execute()
    {
        // Return a zero velocity
        return Vector2.zero;
    }
}
