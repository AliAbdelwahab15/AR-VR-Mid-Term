using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    public string targetTag;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) &&
               (interactable.transform.CompareTag(targetTag));
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) &&
               (interactable.transform.CompareTag(targetTag));
    }
}
