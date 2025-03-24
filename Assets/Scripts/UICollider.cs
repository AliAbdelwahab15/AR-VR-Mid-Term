using UnityEngine;

public class UICollider : MonoBehaviour
{
    [Tooltip("Drag the UI element (GameObject) that you want to toggle here.")]
    public GameObject uiElement;

    [Tooltip("Drag the Light you want to toggle on/off when the player enters/exits the collider.")]
    public Light sceneLight;

    private void Start()
    {
        // Hide the UI element by default.
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Element is not assigned in the inspector.");
        }

        // Turn off the light by default.
        if (sceneLight != null)
        {
            sceneLight.enabled = false;
        }
        else
        {
            Debug.LogWarning("Light is not assigned in the inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged "Player"
        if (other.CompareTag("Player"))
        {
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }

            if (sceneLight != null)
            {
                sceneLight.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is tagged "Player"
        if (other.CompareTag("Player"))
        {
            if (uiElement != null)
            {
                uiElement.SetActive(false);
            }

            if (sceneLight != null)
            {
                sceneLight.enabled = false;
            }
        }
    }
}
