using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<Fire> fireList;
    public float timerToLight;
    public float minTimer;
    public float maxTimer;
    private float thisTimerToLightUp;
    public GameObject fire;
    private void Start()
    {
        AssignFires();  
    }
    // Update is called once per frame
    void Update()
    {
        if (timerToLight <= 0)
        {
            fire.SetActive(true);
        }
        else
        {
            timerToLight -= Time.deltaTime; 
        }

    }
    public void AssignFires() 
    {
        for (int i = 0; i < fireList.Count; ++i)
        {
            fireList[i].timerToLight = Random.Range(minTimer, maxTimer);
            if (i > 0)
            {
                while (fireList[i].timerToLight >= fireList[i - 1].timerToLight + 1 &&
                       fireList[i].timerToLight <= fireList[i - 1].timerToLight - 1)
                {
                    fireList[i].timerToLight = Random.Range(minTimer, maxTimer);
                }
            }
            if (fireList[i] == this)
            {
                thisTimerToLightUp = fireList[i].timerToLight;
            }
        }
    }
}
