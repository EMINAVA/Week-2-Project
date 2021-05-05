using System;
using System.Threading.Tasks;

/// <summary>
/// Overrides <see cref="MovePlatform.Start"/>. It waits a random amount of time between 0 and 2 seconds
/// and sets the moveTime to a random value between 2 and 5.
/// </summary>
public class MovePlatformRandom : MovePlatform
{
	protected override async void Start()
	{
		var random = new Random(GetHashCode());
		moveTime = (float)random.NextDouble() * 3f + 2f;
		await Task.Delay(random.Next(2000));
		base.Start();
	}
}
