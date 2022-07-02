using UnityEngine;

// In order to move an object, the object needs to have this method.
// (If a Rigidbody2D exists on the object).
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    // Movement speed.
    public float speed = 8.0f; // Speed is 8.


    // Speed multiplier.
    public float speedMultiplier = 1.0f; // Speed * 1.

    // Each object might have a different initial direction.
    public Vector2 initialDirection;


    // Select which layer we want to raycasts on (ex. colliding with a wall).
    public LayerMask obstacleLayer;


    public new Rigidbody2D rigidbody { get; private set; } // Public getter, private setter.
    

    // Know which direction the object is currently moving towards.
    public Vector2 direction { get; private set;}


    // To help que the directions of the objects.
    // That way, you don't have to have percise timing when choosing the directions. This will
    // help direction desision making much easier.
    public Vector2 nextDirection { get; private set;}


    // Keep track of the object's starting position. This will help reset the possitions of the
    // objects if/when the game resets.
    public Vector3 startingPosition { get; private set;}


    // When the object is initialized.
    private void Awake()
    {
        // This will always work because of the [RequireComponent(typeof(Rigidbody2D))].
        this.rigidbody = GetComponent<Rigidbody2D>();

        this.startingPosition = this.transform.position;
    }


    private void Start()
    {
        ResetState();
    }
    

    public void ResetState()
    {
        // Brings back the initial values for the objects.
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }


    // 
    private void Update()
    {
        // If the next direction is not zero. Set the next direction as the
        // current one.
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }


    // Applying the movement for the object.
    private void FixedUpdate()
    {
        // Calculate the position.
        Vector2 position = this.rigidbody.position;

        // Calculate how much the user wants to translate.
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;

        // Move the object to the new position.
        this.rigidbody.MovePosition(position + translation);
    }


    // A way to change directions.
    public void SetDirection(Vector2 direction, bool foreced = false)
    {
        // If the tile in the direction is not occupied.
        if (foreced || !Occupied(direction))
        {
            this.direction = direction;

            // Clear up the qued direction.
            this.nextDirection = Vector2.zero;
        }

        // Otherwise, if it is occupied, que new direciton.
        else
        {
            // This will help to keep the next qued direction until there is
            // no occupied direction.
            this.nextDirection = direction;
        }
    }


    // Check to see if the tile is occupied.
    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, 
        direction, 1.5f, this.obstacleLayer);
        
        return hit.collider != null;
    }
}
