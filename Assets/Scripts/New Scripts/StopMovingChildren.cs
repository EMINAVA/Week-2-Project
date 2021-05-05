using UnityEngine;

/// <summary>
/// Destroys all the <see cref="MovePlatform"/>s in the attached <see cref="GameObject"/>'s children on the <see cref="OnCubeEnter"/>
/// method call
/// </summary>
public class StopMovingChildren : CubeAction
{
    public override void OnCubeEnter(GameObject cube)
    {
        // Get components
        MovePlatform[] components = GetComponentsInChildren<MovePlatform>();
        // Destroy every component's GameObject
        foreach (MovePlatform movePlatform in components)
        {
            Destroy(movePlatform.gameObject);
        }
    }
}
