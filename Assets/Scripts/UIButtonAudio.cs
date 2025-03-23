using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAudio : MonoBehaviour
{
    [Tooltip("Assign the primary AudioSource that has the intended AudioClip set on it.")]
    public AudioSource audioSource;

    [Tooltip("Assign the secondary AudioSource to play after the primary clip finishes.")]
    public AudioSource nextAudioSource;

    private Button button;

    void Awake()
    {
        // Get the Button component attached to this GameObject.
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("UIButtonAudio requires a Button component on the same GameObject.");
            return;
        }
        // Register the PlayAudio method for button clicks.
        button.onClick.AddListener(PlayAudio);
    }

    void PlayAudio()
    {
        // Stop all audio in the scene.
        StopAllAudio();

        if (audioSource != null && audioSource.clip != null)
        {
            // Play the primary AudioSource's clip.
            audioSource.Play();
            // Start a coroutine to wait until the primary clip finishes playing.
            StartCoroutine(WaitForPrimaryToFinish());
        }
        else
        {
            Debug.LogWarning("Primary AudioSource or its AudioClip is not assigned on " + gameObject.name);
        }
    }

    IEnumerator WaitForPrimaryToFinish()
    {
        // Wait until the primary audio has finished playing.
        while (audioSource != null && audioSource.isPlaying)
        {
            yield return null;
        }
        // Stop all audio again.
        StopAllAudio();
        // Play the secondary AudioSource's clip.
        if (nextAudioSource != null)
        {
            nextAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Secondary AudioSource not assigned on " + gameObject.name);
        }
    }

    void StopAllAudio()
    {
        // Find all AudioSources in the scene and stop them.
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource src in allAudioSources)
        {
            src.Stop();
            // Disable looping so that any looping sources don't immediately restart.
            src.loop = false;
        }
    }
}
