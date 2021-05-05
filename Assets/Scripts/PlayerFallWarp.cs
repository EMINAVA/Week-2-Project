using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallWarp : MonoBehaviour
{
    public GameObject warpPoint;
    // Added fallback warp position as Vector3
    public Vector3 position;
    public float teleportFloorLevel;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y > teleportFloorLevel) return;

        // If the script is not attached to the player
        if (controller == null)
        {
            // Move the transform
            transform.localPosition = warpPoint == null ? position : warpPoint.transform.position;
            return;
        }

        // If it's attached to a player
        controller.enabled = false;
        controller.transform.position = warpPoint == null ? position : warpPoint.transform.position;
        controller.enabled = true;
    }
}
