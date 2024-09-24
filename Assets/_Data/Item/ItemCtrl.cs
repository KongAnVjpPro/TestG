using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : AnMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespwan();
    }
    protected virtual void LoadItemDespwan()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + " : LoadItemDespawn", gameObject);
    }
}
