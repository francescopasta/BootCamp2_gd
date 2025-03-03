using UnityEngine;

public class FireDestinguish : MonoBehaviour
{
    public float timeToDie;
    public Fire fireScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        if (timeToDie <= 0)
        {
            gameObject.SetActive(false);
            fireScript.AssignFires();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        timeToDie -= Time.deltaTime;
    }
}
