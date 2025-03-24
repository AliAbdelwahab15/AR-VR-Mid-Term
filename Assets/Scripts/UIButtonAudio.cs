using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAudio : MonoBehaviour
{
    [Tooltip("Assign the AudioSource that plays the button click sound.")]
    public AudioSource buttonClickAudioSource;

    [Tooltip("Assign the primary AudioSource that has the intended AudioClip set on it.")]
    public AudioSource audioSource;

    [Tooltip("Assign the secondary AudioSource to play after the primary clip finishes.")]
    public AudioSource nextAudioSource;

    private Button button;

    void Awake()
    {
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
        StartCoroutine(PlayFullAudioSequence());
    }

    IEnumerator PlayFullAudioSequence()
    {
        // Step 1: Stop all audio in the scene.
        StopAllAudio();

        // Step 2: Always play the button click sound first.
        if (buttonClickAudioSource != null && buttonClickAudioSource.clip != null)
        {
            buttonClickAudioSource.Play();
            // Step 3: Wait until the button click sound finishes.
            yield return new WaitUntil(() => !buttonClickAudioSource.isPlaying);
        }
        else
        {
            Debug.LogWarning("Button click AudioSource or its clip is not assigned. Skipping button click sound.");
        }

        // Step 4: Stop all audio again.
        StopAllAudio();

        // Step 5: Play the primary audio clip.
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            // Step 6: Wait until the primary audio finishes.
            yield return new WaitUntil(() => !audioSource.isPlaying);
        }
        else
        {
            Debug.LogWarning("Primary AudioSource or its clip is not assigned. Skipping primary audio.");
        }

        // Step 7: Stop all audio again.
        StopAllAudio();

        // Step 8: Play the secondary audio clip.
        if (nextAudioSource != null && nextAudioSource.clip != null)
        {
            nextAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Secondary AudioSource or its clip is not assigned. Skipping secondary audio.");
        }
    }

    void StopAllAudio()
    {
        // Find all AudioSources in the scene and stop them.
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource src in allAudioSources)
        {
            src.Stop();
            // Disable looping to prevent any looping sources from restarting.
            src.loop = false;
        }
    }
}
