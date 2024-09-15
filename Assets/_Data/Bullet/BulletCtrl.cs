using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletCtrl : AnMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + " : LoadDamageSender", transform.parent);
    }
    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + " : LoadBulletDespawn", transform.parent);
    }
}
