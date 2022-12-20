using UnityEngine;

public class PlayerModel
{
    
    // The sprite for the player
    private Sprite sprite;

    // The speed for the player
    public float speed;

    // The turn angle for the player
    public float turnAngle;

    // The fuel capacity for the player
    public float fuelCapacity;

    // The health for the player
    public float health;

    // Constructor for the player model
    public PlayerModel(Sprite sprite, float speed, float turnAngle, float fuelCapacity, float health)
    {
        this.sprite = sprite;
        this.speed = speed;
        this.turnAngle = turnAngle;
        this.fuelCapacity = fuelCapacity;
        this.health = health;
    }

    // Get the sprite for the player
    public Sprite GetSprite()
    {
        return sprite;
    }

    // Set the sprite for the player
    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    // Get the speed for the player
    public float GetSpeed()
    {
        return speed;
    }

    // Set the speed for the player
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    // Get the turn angle for the player
    public float GetTurnAngle()
    {
        return turnAngle;
    }

    // Set the turn angle for the player
    public void SetTurnAngle(float turnAngle)
    {
        this.turnAngle = turnAngle;
    }

    // Get the fuel capacity for the player
    public float GetFuelCapacity()
    {
        return fuelCapacity;
    }

    // Set the fuel capacity for the player
    public void SetFuelCapacity(float fuelCapacity)
    {
        this.fuelCapacity = fuelCapacity;
    }

    // Get the health for the player
    public float GetHealth()
    {
        return health;
    }

    // Set the health for the player
    public void SetHealth(float health)
    {
        this.health = health;
    }
}

