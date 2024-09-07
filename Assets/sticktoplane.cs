using UnityEngine;
using TMPro;

public class StickToPlane : MonoBehaviour
{
    private static int hitCount = 0; // Static variable to track hits across all balls
    public static int maxBalls = 10; // Static variable to track max balls if needed
    public TextMeshProUGUI scoretext;
    public ParticleSystem explosion; // Reference to the existing Particle System

    void Start()
    {
        if (scoretext == null)
        {
            // Find any TextMeshProUGUI component in the scene
            scoretext = FindObjectOfType<TextMeshProUGUI>();
            if (scoretext != null)
            {
                Debug.Log("Scoretext found: " + scoretext.text); // To verify it's found correctly
            }
            else
            {
                Debug.LogError("No TextMeshProUGUI component found in the scene!");
            }
        }

        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Stick the ball to the plane
            }
            transform.SetParent(collision.transform); // Parent the ball to the plane

            // Increment hit counter
            hitCount++;

            // Update the score text
            UpdateScoreText();

            // Check if all balls have hit the plane
            if (hitCount >= maxBalls)
            {
                Debug.Log("All balls have hit the plane!");
            }

            // Check if hit count has reached 20
            if (hitCount >= 20)
            {
                DestroyAndExplode(collision.gameObject); // Destroy the plane and play the explosion
            }
        }
    }

    private void UpdateScoreText()
    {
        if (scoretext != null)
        {
            scoretext.text = "Hits: " + hitCount + "/" + maxBalls;
        }
        else
        {
            Debug.LogError("Scoretext is still null!");
        }
    }

    private void DestroyAndExplode(GameObject target)
    {
        // Trigger the explosion particle system before destroying the plane
        TriggerExplosion();

        // Destroy the target plane after triggering the explosion
        Destroy(target);
    }

    private void TriggerExplosion()
    {
        if (explosion != null)
        {
            // Play the existing explosion particle system
            explosion.Play();
            Debug.Log("Explosion particle system played.");
        }
        else
        {
            Debug.LogError("No ParticleSystem component assigned to the explosion!");
        }
    }
}
