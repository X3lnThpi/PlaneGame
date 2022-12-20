using UnityEngine;

public class HomingMissileModel
{
    // The sprite for the Missile
    private Sprite sprite;

    // The duration of the missile
    public float duration;

    //Missile Speed
    public float speed = 0f;

    //Turn Rate
    public float turnRate = 30f;

    // The damage amount of the missile
    public float damageAmount;

    // A reference to the player object that the homing missile is targeting
    public GameObject player;

    //// Loads the default values for the homing missile's properties from a scriptable object
    //public void LoadDefaultValues(HomingMissileDefaultValues defaultValues)
    //{
    //    duration = defaultValues.duration;
    //    speed = defaultValues.speed;
    //    turnRate = defaultValues.turnRate;
    //}

    // Constructor for the HomingMissileModel
    public HomingMissileModel(float duration, float damageAmount)
    {
        this.duration = duration;
        this.damageAmount = damageAmount;
    }

    // Get the duration of the missile
    public float GetDuration()
    {
        return duration;
    }

    // Set the duration of the missile
    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    // Get the damage amount of the missile
    public float GetDamageAmount()
    {
        return damageAmount;
    }

    // Set the damage amount of the missile
    public void SetDamageAmount(float damageAmount)
    {
        this.damageAmount = damageAmount;
    }

    // Get the sprite for the Missile
    public Sprite GetSprite()
    {
        return sprite;
    }

    // Set the sprite for the Missile
    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }
}
