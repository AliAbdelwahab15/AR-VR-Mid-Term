using UnityEngine;
using UnityEngine.UI;

public class ToggleLightButton : MonoBehaviour
{
    public Light targetLight;
    public AudioSource audioSource;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleLight);
    }

    void ToggleLight()
    {
        if (targetLight != null)
        {
            targetLight.enabled = !targetLight.enabled;
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
