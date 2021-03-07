using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]

public class weapon1911 : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] private float damage;

    private Rigidbody rb;
    private XRGrabInteractable xrg;

    protected virtual void Awake()
    {
        xrg = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        setupInteractableWeaponsEvents();
    }

    [Obsolete]
    private void setupInteractableWeaponsEvents()
    {
        xrg.onSelectEnter.AddListener(PickUpWeapon);
        xrg.onSelectExit.AddListener(DropWeapon);
        xrg.onActivate.AddListener(StartShooting);
        xrg.onDeactivate.AddListener(StopShooting);
    }

    private void PickUpWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<meshHidder>().Hide();
    }
    private void DropWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<meshHidder>().Show(); 
    }
    protected virtual void StartShooting(XRBaseInteractor interactor)
    {
        throw new NotImplementedException();
    }
    protected virtual void StopShooting(XRBaseInteractor interactor)
    {
        throw new NotImplementedException();
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rb.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float getShootingForce()
    {
        return shootingForce;
    }

    //public float getDamage()
    
}
