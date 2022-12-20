using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target; // the target to home in on
    public float speed = 10f; // the speed of the missile
    private Rigidbody2D rb; // the Rigidbody2D component of the missile
    public float radius = 0.5f; // the radius of the collider for hitting the target
    public LayerMask hitLayer; // the layer to check for hitting the target
    public GameObject explosionPrefab; // the prefab for the explosion effect when the missile hits the target

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the Rigidbody2D component
    }

    void Update()
    {
        // check if the missile has hit the target
        if (Physics2D.OverlapCircle(transform.position, radius, hitLayer))
        {
            // instantiate the explosion prefab at the position of the missile
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            // destroy the explosion after a few seconds
            Destroy(explosion, 3f);
            // destroy the missile
            Destroy(gameObject);
            return;
        }

        // rotate towards the target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, GetTargetRotation(), 200f * Time.deltaTime);

        // move towards the target
        rb.velocity = transform.up * speed;
    }

    // returns the rotation to the target
    Quaternion GetTargetRotation()
    {
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}


