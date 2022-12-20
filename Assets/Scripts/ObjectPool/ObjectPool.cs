using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // The prefab to instantiate
    [SerializeField]
    private GameObject prefab;

    // The time between missiles
    [SerializeField]
    private float timeBetweenMissiles;

    // The amount of missiles to have in the pool
    [SerializeField]
    private int amountOfMissiles;

    // The queue for storing inactive missiles
    private Queue<GameObject> inactiveMissiles;

    // The timer for firing missiles
    private float timer;

    void Start()
    {
        // Initialize the queue and timer
        inactiveMissiles = new Queue<GameObject>();
        timer = timeBetweenMissiles;

        // Populate the queue with the initial amount of missiles
        for (int i = 0; i < amountOfMissiles; i++)
        {
            GameObject missile = Instantiate(prefab);
            missile.SetActive(false);
            inactiveMissiles.Enqueue(missile);
        }
    }

    void Update()
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // If the timer has reached zero, fire a missile
        if (timer <= 0f)
        {
            timer = timeBetweenMissiles;
            FireMissile();
        }
    }

    // Fire a missile from the pool
    public void FireMissile()
    {
        // If there are no inactive missiles in the queue, return
        if (inactiveMissiles.Count == 0)
        {
            return;
        }

        // Dequeue an inactive missile from the queue and set it to active
        GameObject missile = inactiveMissiles.Dequeue();
        missile.SetActive(true);

        // Set the missile's position to be outside the visible screen
        missile.transform.position = new Vector3(Screen.width + 50f, Random.Range(-Screen.height / 2f, Screen.height / 2f), 0f);
    }

    // Return a missile to the queue
    public void ReturnMissileToPool(GameObject missile)
    {
        // Set the missile to inactive and add it to the queue
        missile.SetActive(false);
        inactiveMissiles.Enqueue(missile);
    }
}
