using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    private MeshRenderer ballRenderer;
    private new Light light;

    private void Start()
    {
        ballRenderer = GetComponent<MeshRenderer>();
        light = GetComponentInChildren<Light>() ?? GetComponent<Light>();

        light.enabled = false;
        if (ballRenderer == null) return;
        ballRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        light.enabled = true;
        if (ballRenderer == null) return;
        ballRenderer.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        light.enabled = false;
        if (ballRenderer == null) return;
        ballRenderer.enabled = false;
    }

}
