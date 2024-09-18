using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpart : BulletAbstract
{
    [Header("BulletImpart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigibody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.1f;
        Debug.Log(transform.name + " : LoadCollider", gameObject);
    }
    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody>();
        this._rigibody.isKinematic = true;
        Debug.Log(transform.name + " : LoadRigibody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletCtrl.Shooter) return;


        this.BulletCtrl.DamageSender.Send(other.transform);
        this.createImpactFX(other);
    }
    protected virtual void createImpactFX(Collider other)
    {
        string fxName = this.GetImpactFX();
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }
}
