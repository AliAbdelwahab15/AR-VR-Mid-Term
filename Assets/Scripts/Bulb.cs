using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bulb : MonoBehaviour
{
    public Light targetLight;
    public AudioSource remoteAudioSource;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(OnRemoteActivated);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
            grabInteractable.activated.RemoveListener(OnRemoteActivated);
    }

    private void OnRemoteActivated(ActivateEventArgs args)
    {
        if (targetLight != null)
        {
            targetLight.enabled = !targetLight.enabled;
        }

        // Play the click sound using the assigned AudioSource.
        if (remoteAudioSource != null)
        {
            remoteAudioSource.Play();
        }
    }
}
