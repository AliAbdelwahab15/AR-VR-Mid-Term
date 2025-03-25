using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAudio : MonoBehaviour
{
    public AudioSource buttonClickAudioSource;
    public AudioSource audioSource;
    public AudioSource nextAudioSource;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayAudio);
    }

    void PlayAudio()
    {
        StartCoroutine(PlayFullAudioSequence());
    }

    IEnumerator PlayFullAudioSequence()
    {
        StopAllAudio();
        if (buttonClickAudioSource != null && buttonClickAudioSource.clip != null)
        {
            buttonClickAudioSource.Play();
            yield return new WaitUntil(() => !buttonClickAudioSource.isPlaying);
        }

        StopAllAudio();

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            yield return new WaitUntil(() => !audioSource.isPlaying);
        }

        StopAllAudio();

        if (nextAudioSource != null && nextAudioSource.clip != null)
        {
            nextAudioSource.Play();
        }
    }

    void StopAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource src in allAudioSources)
        {
            src.Stop();
            src.loop = false;
        }
    }
}
