using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{
    private bool lightOn = true;
    public float timerLightOnLength = 2f;
    public float timerLightOffLength = 3f;
    private float timeLeftOn;
    private float timeLeftOff;

    private new Light light;

    // Start is called before the first frame update
    private void Start()
    {
        light = GetComponent<Light>();

        timeLeftOn = timerLightOnLength;
        timeLeftOff = timerLightOffLength;
    }

    // Update is called once per frame
    private void Update()
    {
        if (lightOn)
        {
            timeLeftOn -= Time.deltaTime;
            if (!(timeLeftOn <= 0)) return;
            timeLeftOff = timerLightOffLength;
            lightOn = false;
            light.enabled = false;
        }
        else
        {
            timeLeftOff -= Time.deltaTime;
            if (!(timeLeftOff <= 0)) return;
            timeLeftOn = timerLightOnLength;
            lightOn = true;
            light.enabled = true;
        }

    }
}
