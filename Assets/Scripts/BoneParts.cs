using System.Collections;
using UnityEngine;

public class BoneParts : MonoBehaviour
{
    private float hitCooldown = 0.5f; // Cooldown time in seconds
    private float lastHitTime = -Mathf.Infinity; // Time of the last hit, initialized to negative infinity
    private Renderer rend; // Reference to the Renderer component of the bone part
    private Color originalColor; // Store the original color of the bone part

    void Awake()
    {
        rend = GetComponent<Renderer>(); // Get the Renderer component
        originalColor = rend.material.color; // Store the original color
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return; // Only react to collisions with objects tagged as "Obstacle"
        if (Time.time - lastHitTime < hitCooldown) return; // Check if we're still in the cooldown period

        lastHitTime = Time.time; // Update the last hit time
        ScoreManager.Instance?.AddScore(); // Add score through the ScoreManager singleton instance

        StartCoroutine(FlashRed()); // Start the coroutine to flash red
    }

    IEnumerator FlashRed()
    {
        rend.material.color = Color.red; // Change color to red
        yield return new WaitForSeconds(hitCooldown); // Wait for the cooldown duration
        rend.material.color = originalColor; // Revert to the original color
    }
}
