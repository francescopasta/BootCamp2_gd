using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 3.0f; // Speed at which the enemy moves
    public float stoppingDistance = 1.0f; // Distance at which the enemy stops moving

    private Transform player; // Reference to the player's transform
    private Rigidbody rb; // Reference to the enemy's Rigidbody

    void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player is tagged as 'Player'.");
        }

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the enemy!");
        }
        else
        {
            // Freeze the Y position in the Rigidbody constraints
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }

    void FixedUpdate()
    {
        if (player != null && rb != null)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Only move if the enemy is farther than the stopping distance
            if (distanceToPlayer > stoppingDistance)
            {
                // Calculate the direction to the player (ignoring the Y-axis)
                Vector3 direction = (player.position - transform.position).normalized;
                direction.y = 0; // Ensure no movement on the Y-axis

                // Move the enemy towards the player using Rigidbody velocity
                rb.linearVelocity = direction * speed;
            }
            else
            {
                // Stop moving if within stopping distance
                rb.linearVelocity = Vector3.zero;
            }
        }
    }

    // This method is called when the enemy collides with another Collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the method to handle the collision with the player
            HandlePlayerCollision();
        }
    }

    // Method to handle what happens when the player collides with the enemy
    private void HandlePlayerCollision()
    {
        // This method is empty, you can fill it with your desired behavior
        // For example, you could damage the player, play a sound, or trigger an animation
    }
}