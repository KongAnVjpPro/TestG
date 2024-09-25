using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //   [Header("Drop Item")]

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 6);
    }

    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }
    protected virtual void DropItemIndex(int index)
    {
        ItemInventory itemInventory = this.inventory.Items[index];
        Debug.Log(itemInventory.itemProfile.itemCode);
        Debug.Log(itemInventory.upgradeLevel);


        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        Quaternion rot = transform.rotation;
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, rot);
        this.inventory.Items.Remove(itemInventory);

    }


}
