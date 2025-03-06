using UnityEngine;

public class PissRunOutBehaviour : MonoBehaviour
{
    private float pissTimer;
    public float runOutTime = 5f; // Default max pee time
    public float fastDrainMultiplier = 2f; // Drains twice as fast when RMB is held

    public ParticleSystem piss;

    private void Awake()
    {
        piss.Play();
    }

    void Start()
    {
        pissTimer = 0;
    }

    void Update()
    {
        if (pissTimer < runOutTime)
        {
            // Normal drain rate
            float drainSpeed = Time.deltaTime;

            // Faster drain when RMB is held
            if (Input.GetMouseButton(1))
            {
                drainSpeed *= fastDrainMultiplier;
            }

            pissTimer += drainSpeed;
            Debug.Log($"Piss Timer: {pissTimer}");
        }
        else
        {
            piss.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            DrinkWater();
        }
    }

    void DrinkWater()
    {
        pissTimer = 0; // Reset pee timer
        piss.Play();
    }
}
