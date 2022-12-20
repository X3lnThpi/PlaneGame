using UnityEngine;

// A scriptable object to hold the default values for the player character's properties
[CreateAssetMenu(menuName = "Player/Player Default Values")]
public class PlayerDefaultValues : ScriptableObject
{
    public float speed = 10f;
    public float turnAngle = 90f;
    public float fuelCapacity = 100f;
    public float health = 100f;
}