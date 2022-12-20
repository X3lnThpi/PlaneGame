using UnityEngine;

// A scriptable object to hold the default values for the homing missile's properties
[CreateAssetMenu(menuName = "Missiles/Homing Missile Default Values")]
public class HomingMissileDefaultValues : ScriptableObject
{
    public float duration = 10f;
    public float speed = 10f;
    public float turnRate = 90f;
}