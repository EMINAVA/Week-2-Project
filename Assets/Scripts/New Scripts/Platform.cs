using UnityEngine;

/// <summary>
/// Makes the player a child of this <see cref="GameObject"/>'s parent, so that it moves with the platform
/// </summary>
public class Platform : MonoBehaviour
{
	// Set the player's parent when he enters the trigger
	private void OnTriggerEnter(Collider collision)
    {
	    if (!collision.CompareTag("Player")) return;

	    collision.gameObject.transform.parent = transform.parent;
    }

	// Set the player's parent to null when he leaves the trigger
	private void OnTriggerExit(Collider collision)
	{
		if (!collision.CompareTag("Player")) return;

		if (collision.gameObject.transform.parent != transform.parent) return;
		
		collision.gameObject.transform.parent = null;
	}
}
