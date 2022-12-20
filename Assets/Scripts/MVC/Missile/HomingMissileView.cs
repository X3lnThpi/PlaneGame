using UnityEngine;

public class HomingMissileView : MonoBehaviour
{
    // The HomingMissileModel
    private HomingMissileModel homingMissileModel;

    // The sprite renderer for rendering the missile sprite
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Get the sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Set the HomingMissileModel
    public void SetHomingMissileModel(HomingMissileModel homingMissileModel)
    {
        this.homingMissileModel = homingMissileModel;
    }

    void Update()
    {
        // Update the player sprite based on the player model's properties
        spriteRenderer.sprite = homingMissileModel.GetSprite();
    }
}
