using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushActivateObject : MonoBehaviour
{
    // We'll reference an XRBaseInteractable on the same GameObject.
    private XRBaseInteractable interactable;

    [Header("Audio Setup")]
    [Tooltip("Drag the AudioSource here (can be on this object or another).")]
    public AudioSource audioSource;

    [Tooltip("Drag the AudioClip you want to play here.")]
    public AudioClip audioClip;

    private void Start()
    {
        // Try to get the XRBaseInteractable from this GameObject.
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable == null)
        {
            Debug.LogError("No XRBaseInteractable found on " + gameObject.name);
            return;
        }

        // Add a listener to play the audio when the button is pressed.
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDestroy()
    {
        // Always remove listeners to avoid memory leaks or errors.
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        PlayAudio();
    }

    private void PlayAudio()
    {
        Debug.Log("PlayAudio() called!");
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not assigned on " + gameObject.name);
        }
    }
}
