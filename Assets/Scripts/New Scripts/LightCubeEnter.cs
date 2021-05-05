using UnityEngine;

/// <summary>
/// Calls <see cref="CubeAction.OnCubeEnter"/> of the <see cref="target"/> object when a cube enters a trigger collider.
/// </summary>
public class LightCubeEnter : MonoBehaviour
{
	public CubeAction target;
	private void OnTriggerEnter(Collider other)
	{
		// Check that it's a cube and that it is not its trigger but the body itself
		if (!other.CompareTag("Cube") || other.isTrigger) return;

		// Call the target's OnCubeEnter
		target.OnCubeEnter(other.gameObject);
	}
}

/// <summary>
/// Abstract class with the OnCubeEnter method
/// </summary>
public abstract class CubeAction : MonoBehaviour
{
	public abstract void OnCubeEnter(GameObject cube);
}
