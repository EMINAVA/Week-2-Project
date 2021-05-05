using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Rotates a platform by <see cref="yRotation"/> in <see cref="duration"/> seconds after 1s from the <see cref="OnCubeEnter"/>
/// method call.
/// </summary>
public class RotateYOnCubeEnter : CubeAction
{
	public float yRotation;
	public float duration;
	private float originalY;
	private float? currentTime;
	
	public override async void OnCubeEnter(GameObject _)
	{
		// Wait 1s asynchronously
		await Task.Delay(1000);
		// Set the currentTime to 0
		currentTime = 0;
	}

	private void Start()
	{
		// Set the original Y
		originalY = transform.eulerAngles.y;
	}
	
	private void FixedUpdate()
	{
		// If there is no animation, return
		if (currentTime == null) return;

		// Calculate and apply new rotation
		Vector3 rot = transform.eulerAngles;
		rot.y = originalY + yRotation * ((float)currentTime / duration);
		transform.eulerAngles = rot;
	}
	
	private void Update()
	{
		// If there is no animation, return
		if (currentTime == null) return;
		
		currentTime += Time.deltaTime;
		
		// If the animation is not done, return
		if (currentTime < duration) return;
		
		// Set the final rotation
		Vector3 rotation = transform.eulerAngles;
		rotation.y = originalY + yRotation;
		transform.eulerAngles = rotation;
		// Stop the animation
		currentTime = null;
	}
}
