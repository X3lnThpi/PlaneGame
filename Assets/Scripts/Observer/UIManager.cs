// The UIManager class handles the updating of UI elements
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // The UI element for displaying the player's health
    public Text playerHealthText;

    // The UI element for displaying the number of missiles hit
    public Text missilesHitText;

    // The UI element for displaying the number of missiles evaded
    public Text missilesEvadedText;

    // The player's current health
    public float playerHealth;

    // The number of missiles hit
    public int missilesHit;

    // The number of missiles evaded
    public int missilesEvaded;

    void Awake()
    {
        // Initialize the UI elements with default values
        playerHealthText.text = "Player Health: " + playerHealth;
        missilesHitText.text = "Missiles Hit: " + missilesHit;
        missilesEvadedText.text = "Missiles Evaded: " + missilesEvaded;
    }

    // Called by the IUIManagerObserver to update the UIManager's properties
    public void UpdateProperties(IUIManagerObserver observer)
    {
        observer.OnUpdateUIManager(this);
    }
}