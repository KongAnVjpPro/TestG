using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " : LoadJunkCtrl", transform.parent);
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.junkCtrl.JunkDespawn.DespawnObject();

        //drop item
        DropManager.Instance.Drop(this.junkCtrl.JunkSO.dropList);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
    protected override void Reborn()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
