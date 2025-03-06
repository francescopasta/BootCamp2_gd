using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public bool isGettingPissed = false;
    private float pissTimer;
    public float deathTimer = 5f; // Set default death time
    private Renderer enemyRenderer;
    public Color startColor = Color.white; // Default color
    public Color endColor = Color.red; // Color when close to death

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();

        if (enemyRenderer == null)
        {
            Debug.LogError("No Renderer found on the enemy!");
        }
    }

    void Update()
    {
        if (enemyRenderer != null)
        {
            float progress = pissTimer / deathTimer; // Get percentage of time elapsed
            enemyRenderer.material.color = Color.Lerp(startColor, endColor, progress);
        }

        if (pissTimer >= deathTimer)
        {
            Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        pissTimer += Time.deltaTime;
        Debug.Log(pissTimer);
    }
}
