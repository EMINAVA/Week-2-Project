using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Toggles an object on and off every <see cref="AppearAndDisappear.period"/> seconds
/// </summary>
public class AppearAndDisappear : MonoBehaviour
{
	public float period;
	
	// On/Off
	private bool state = true;

	private CancellationTokenSource cts;
	/// <summary>
	/// Starts toggling the object
	/// </summary>
	public void Start()
	{
		cts = new CancellationTokenSource();
		// Start Async function without awaiting with CancellationToken
		TogglePeriodically(cts.Token).ConfigureAwait(false);
	}

	/// <summary>
	/// Stops the toggling of the object
	/// </summary>
	public void Stop()
	{
		// Cancel the operation
		cts.Cancel();
		cts.Dispose();
	}

	/// <summary>
	/// Cancel the task when the object is destroid
	/// </summary>
	public void OnDestroy()
	{
		cts.Cancel();
	}

	// Toggle the object every period 
	private async Task TogglePeriodically(CancellationToken ct)
	{
		// Until cancellation is requested
		while (true)
		{
			// Wait period
			await Task.Delay((int)(period * 1000), ct);
			// If cancellation is requested, quit
			if (ct.IsCancellationRequested) return;
			// Toggle the object
			state = !state;
			gameObject.SetActive(state);
		}
	}
}
