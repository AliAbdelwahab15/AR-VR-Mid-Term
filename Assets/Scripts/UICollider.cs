using UnityEngine;

public class UICollider : MonoBehaviour
{
    [Tooltip("Drag the UI element (GameObject) that you want to toggle here.")]
    public GameObject uiElement;

    private void Start()
    {
        // Make sure the UI element is hidden by default.
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Element is not assigned in the inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            if (uiElement != null)
            {
                uiElement.SetActive(false);
            }
        }
    }
}
