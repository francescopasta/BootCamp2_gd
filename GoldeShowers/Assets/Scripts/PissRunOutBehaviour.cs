using UnityEngine;

public class PissRunOutBehaviour : MonoBehaviour
{
    private float pissTimer;
    public float runOutTime;

    public ParticleSystem piss;

    private void Awake()
    {
        piss.Play();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pissTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pissTimer < runOutTime) 
        {
            pissTimer += Time.deltaTime;
            Debug.Log(pissTimer.ToString());
        }
        else
        {
            piss.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DrinkWater();
            }
        }
    }

    void DrinkWater()
    {
        pissTimer = 0;
        piss.Play();
    }
}
