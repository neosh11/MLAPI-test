using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinwheel.Jupiter;

public class SkyControls : MonoBehaviour
{
    [SerializeField] private JDayNightCycle dayNightCycle;
    // per second?
    [SerializeField] float timeSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle.Time = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = timeSpeed * Time.deltaTime;
        dayNightCycle.Time = dayNightCycle.Time + movement;
    }
}
