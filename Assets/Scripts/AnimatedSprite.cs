using UnityEngine;

// Make a way to say in order to have an animated sprite, you must have the SpriteRenderer.
// In other words, you can't have an animated sprite without the SpriteRenderer on that 
// object.
[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; } // public getter, private setter.

    // Array of sprites to loop through.
    public Sprite[] sprites;

    // Give a grace period before moving to the next sprite.
    public float animationTime = 0.25f; // Quarter of a second wait before the next sprite.

    // Know which index we are currently on.
    public int animationFrame { get; private set; }

    // If the sprite should loop or not.
    public bool loop = true; // by default.

    // When the object is initialized.
    private void Awake()
    {
        // This will always work because of the [RequireComponent(typeof(SpriteRenderer))].
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // This will invoke a certain amount of seconds.
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime); // initial time and time thereafter.
    }

    // Function for the Invoke.
    private void Advance()
    {
        // If you turn of the sprite renderer, turn of the animation.
        if (!this.spriteRenderer.enabled)
        {
            // Return instantly and not do anything.
            return;
        }

        // Increment the sprite frame.
        this.animationFrame++;

        // Check to see if the sprite needs to loop. If the animation frame is greater than the amount of sprites that the
        // object has and is looping.
        if (this.animationFrame >= this.sprites.Length && this.loop)
        {
            // Revert back to 0.
            this.animationFrame = 0;
        }

        // Makes sure that the index won't be out of range.
        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
        {
            // Set the sprite to the current animation frame.
            this.spriteRenderer.sprite = this.sprites[this.animationFrame];
        }

    }

    // Restarts the aniimation back to 0.
        public void Restart()
        {
            this.animationFrame = -1;

            Advance();
        }
    
}
