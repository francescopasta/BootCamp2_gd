using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public bool isGettingPissed = false;
    private float pissTimer;
    public float deathTimer;
    // Update is called once per frame
    void Update()
    {

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
