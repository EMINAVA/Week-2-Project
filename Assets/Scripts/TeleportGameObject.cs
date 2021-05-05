using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TeleportGameObject : MonoBehaviour
{
    public GameObject target;
    public Vector3 teleportLocation;

    public void Start()
    {
        if (target == null) target = gameObject;
    }

    private void Teleport()
    {
        var controller = target.GetComponent<CharacterController>();

        if (controller == null) return;
        controller.enabled = false;
        controller.transform.position = teleportLocation;
        controller.enabled = true;
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;

        TeleportWithDelay().ConfigureAwait(false);
    }

    // Added teleport with delay
    private async Task TeleportWithDelay()
    {
        await Task.Delay(1000);
        Teleport();
    }
}
