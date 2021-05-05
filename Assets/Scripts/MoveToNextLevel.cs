using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        NextScene().ConfigureAwait(false);
    }

    // Added delay to level change
    private async Task NextScene()
    {
        await Task.Delay(2000);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Imported snippet
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        } 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
