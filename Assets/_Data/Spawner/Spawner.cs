using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class Spawner : AnMonoBehavior
{
    [SerializeField] protected List<Transform> prefabs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + " : LoadPrefabs", gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("prefab not found :" + prefabName);
            return null;
        }
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string name)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == name) return prefab;
        }
        return null;
    }
}
