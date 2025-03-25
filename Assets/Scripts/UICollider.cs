using UnityEngine;

public class UICollider : MonoBehaviour
{
    public GameObject uiElement;
    public Light sceneLight;

    private void Start()
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

    private void OnTriggerEnter(Collider other)
    {
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
