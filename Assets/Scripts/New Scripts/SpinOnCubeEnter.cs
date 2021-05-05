using UnityEngine;

/// <summary>
/// Enables the <see cref="SpinObject"/> component of this <see cref="GameObject"/> when the <see cref="OnCubeEnter"/> method is called
/// </summary>
public class SpinOnCubeEnter : CubeAction
{
	private SpinObject spinObject;

	private void Start()
	{
		// Get the component
		spinObject = GetComponent<SpinObject>();
		// If there is none, return
		if (spinObject == null) return;
		// Stop the spinning
		spinObject.Spinning = false;
	}
	
	public override void OnCubeEnter(GameObject cube)
	{
		// If there is no component, return
		if (spinObject == null) return;
		// Start spinning
		spinObject.Spinning = true;
	}
}
