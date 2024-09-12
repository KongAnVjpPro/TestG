using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.name + " : Load Camera", gameObject);
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance >= this.disLimit) return true;
        return false;
    }
}
