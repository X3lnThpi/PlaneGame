using UnityEngine;

public class PlayerView : MonoBehaviour
{
    // The player model
    private PlayerModel playerModel;

    // The sprite renderer for rendering the player sprite
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Get the sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Set the player model
    public void SetPlayerModel(PlayerModel playerModel)
    {
        this.playerModel = playerModel;
    }

    void Update()
    {
        // Update the player sprite based on the player model's properties
        spriteRenderer.sprite = playerModel.GetSprite();
    }
}
