using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : AnMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + " : LoadInventory", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.LogWarning(transform.name + " : LoadCollider", gameObject);
    }
    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = transform.GetComponent<Rigidbody>();
        this._rigibody.useGravity = false;
        this._rigibody.isKinematic = true;
        Debug.LogWarning(transform.name + " : LoadRigibody", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {

        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }


    }
}
