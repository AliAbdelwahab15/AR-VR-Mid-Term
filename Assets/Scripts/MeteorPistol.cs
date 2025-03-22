using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener((_) => StartShoot());
        grabInteractable.deactivated.AddListener((_) => StopShoot());
    }

    public LayerMask breakableLayer;
    public Transform shootSource;
    public float shootDistance = 10f;

    void StartShoot()
    {
        particles.Play();
        RaycastHit hit;
        if (Physics.Raycast(shootSource.position, shootSource.forward, out hit, shootDistance, breakableLayer))
        {
            if (hit.collider.TryGetComponent(out Breakable breakable))
            {
                breakable.Break();
            }
        }
    }


    void StopShoot()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
