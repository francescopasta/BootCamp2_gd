using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<Fire> fireList;
    public float minTimer;
    public float maxTimer;
    public float minTimeBtwFlames;
    private float timerToLight;
    public GameObject fire;

    private void Start()
    {
        AssignFires();
    }

    void Update()
    {
        if (!fire.activeSelf) // Only count down when fire is disabled
        {
            timerToLight -= Time.deltaTime;
            if (timerToLight <= 0)
            {
                fire.SetActive(true); // Re-enable fire when timer reaches 0
            }
        }
    }

    public void AssignFires()
    {
        for (int i = 0; i < fireList.Count; i++)
        {
            if (fireList[i].timerToLight == 0)
            {
                fireList[i].timerToLight = Random.Range(minTimer, maxTimer);
            }

            if (i > 0)
            {
                while (!(fireList[i].timerToLight >= fireList[i - 1].timerToLight + minTimeBtwFlames ||
                         fireList[i].timerToLight <= fireList[i - 1].timerToLight - minTimeBtwFlames))
                {
                    fireList[i].timerToLight = Random.Range(minTimer, maxTimer);
                }
            }
        }
    }

    public void DisableFire()
    {
        fire.SetActive(false);
        timerToLight = Random.Range(minTimer, maxTimer); // Assign a new countdown timer
    }
}
