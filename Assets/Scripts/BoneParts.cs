using System.Collections;
using UnityEngine;

public class BoneParts : MonoBehaviour
{
    [SerializeField] private float hitCooldown = 1f;
    private float lastHitTime = -Mathf.Infinity;
    private Renderer rend;
    private Color originalColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;
        if (Time.time - lastHitTime < hitCooldown) return;

        lastHitTime = Time.time;
        ScoreManager.Instance?.AddScore();

        StartCoroutine(FlashRed());
    }

    IEnumerator FlashRed()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(hitCooldown);
        rend.material.color = originalColor;
    }
}
