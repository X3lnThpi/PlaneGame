// The Controller class handles user input and updates the Model and View as needed
using UnityEngine;

public class HomingMissileController : MonoBehaviour
{
    // The Model for the homing missile
    public HomingMissileModel homingMissileModel;

    // The HomingMissileView
    private HomingMissileView homingMissileView;

    // The default values for the homing missile's properties
    public HomingMissileDefaultValues defaultValues;

    // A reference to the player object that the homing missile is targeting
    public GameObject player;

    // A reference to the UIManager
    public UIManager uiManager;

    // The elapsed time since the homing missile was launched
    private float elapsedTime;

    //Target Gameobject
    GameObject target;

    // Constructor for the HomingMissileController
    public HomingMissileController(HomingMissileModel homingMissileModel, HomingMissileView homingMissileView, GameObject target, float speed)
    {
        this.homingMissileModel = homingMissileModel;
        this.homingMissileView = homingMissileView;
        this.target = target;
        Debug.Log("Missile Activated");
        //this.speed = speed;
        //timeRemaining = homingMissileModel.GetDuration();
    }


    void Start()
    {
        // Set the player reference in the Model
        homingMissileModel.player = player;

        // Load the default values for the homing missile's properties
        // homingMissileModel.LoadDefaultValues(defaultValues);

        // Load the homing missile sprite
        // homingMissileModel.LoadSprite("HomingMissileSprite");
    }

    void Update()
    {
        // Check if the duration has expired
        if (elapsedTime >= homingMissileModel.duration)
        {
            // The duration has expired

            // Stop chasing the player and fall to the ground
            homingMissileModel.speed = 0f;
            GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            // The duration has not expired

            // Calculate the direction to the player
            Vector3 direction = player.transform.position - transform.position;

            // Rotate towards the player
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), homingMissileModel.turnRate * Time.deltaTime);

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, homingMissileModel.speed * Time.deltaTime);

            // Check for collisions with the player
            if (Vector3.Distance(transform.position, player.transform.position) < 0.5f)
            {
                // The homing missile has collided with the player

                // Deduct the player's health by the homing missile's damage amount
                PlayerModel playerModel = player.GetComponent<PlayerModel>();
                playerModel.health -= homingMissileModel.damageAmount;

                // Destroy the homing missile
                Destroy(gameObject);
            }
        }

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;
    
}

    void OnCollisionEnter(Collision collision)
    {
        // Check if the missile has collided with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // The missile has collided with the player

            // Update the player's health and the missiles hit in the UIManager
            uiManager.playerHealth--;
            uiManager.missilesHit++;

            // Call the UpdateProperties method to update the UI elements
            uiManager.UpdateProperties((IUIManagerObserver)this);
        }
    }

    // Called by the UIManager to update the UIManager's properties
    public void OnUpdateUIManager(UIManager uiManager)
    {
        // Update the UI elements with the updated values
        uiManager.playerHealthText.text = "Player Health: " + uiManager.playerHealth;
        uiManager.missilesHitText.text = "Missiles Hit: " + uiManager.missilesHit;
    }
}

