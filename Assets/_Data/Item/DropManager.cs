using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : AnMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("only 1 dropmanager", gameObject);
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
