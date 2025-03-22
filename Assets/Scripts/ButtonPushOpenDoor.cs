using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushActivateObject : MonoBehaviour
{
    private XRBaseInteractable interactable;

    public GameObject pistol;

    private void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        // Add a listener to the select event that toggles the door.
        interactable.selectEntered.AddListener((args) => TogglePistol());
    }

    private void TogglePistol()
    {
        bool isActive = pistol.activeInHierarchy;
        isActive = !isActive;
        pistol.SetActive(isActive);
    }
}
