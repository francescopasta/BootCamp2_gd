using UnityEditor.SearchService;
using UnityEngine;

public class FireDestinguish : MonoBehaviour
{
    public float timeToDie;
    public Fire fireScript;
    public float ogTimeToDie;

    public float loseTimer;
    public float ogloseTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        if (timeToDie <= 0)
        {
            gameObject.SetActive(false);
        }
        if (loseTimer > 0)
        {
            loseTimer -= Time.deltaTime;    
        }
        if (loseTimer <= 0)
        {
            Debug.Log("You lose");
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        timeToDie -= Time.deltaTime;
    }
    private void OnDisable()
    {
        timeToDie = ogTimeToDie;
        loseTimer = ogloseTime;
        fireScript.DisableFire();
    }
}
