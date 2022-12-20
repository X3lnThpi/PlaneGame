using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // The Model for the player character
    public PlayerModel playerModel;

    // The view for the player character
    public PlayerView playerView;

    // The default values for the player's properties
    public PlayerDefaultValues defaultValues;

    // Constructor for the PlayerController
    public PlayerControl(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;
    }

    void Start()
    {
        //// Load the default values for the player's properties
        //playerModel.LoadDefaultValues(defaultValues);
    }

    // Called when the user selects a new player sprite from the UI
    public void OnSpriteSelected(string spriteName)
    {
        //// Load the selected sprite
        //playerModel.LoadSprite(spriteName);
    }
}