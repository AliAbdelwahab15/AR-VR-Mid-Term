using UnityEngine;
using UnityEngine.UI;

public class ToggleLightButton : MonoBehaviour
{
    [Tooltip("Assign the Light you want to toggle on/off.")]
    public Light targetLight;

    [Tooltip("Assign the AudioSource that will play the button click sound. It should already have the AudioClip assigned.")]
    public AudioSource audioSource;

    private Button button;

    void Awake()
    {
        // Get the Button component attached to this GameObject.
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("ToggleLightButton requires a Button component on the same GameObject.");
            return;
        }
        // Add a listener to toggle the light and play the sound when the button is clicked.
        button.onClick.AddListener(ToggleLight);
    }

    void ToggleLight()
    {
        // Toggle the target light.
        if (targetLight != null)
        {
            targetLight.enabled = !targetLight.enabled;
        }
        else
        {
            Debug.LogWarning("No target Light assigned.");
        }

        // Play the click sound from the AudioSource.
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned.");
        }
    }
}
