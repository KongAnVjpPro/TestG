using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : AnMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + " : LoadHolder", gameObject);
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
        // Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
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

    public virtual void Despawn(Transform transform)
    {
        this.poolObjs.Add(transform);
        transform.gameObject.SetActive(false);
        this.spawnedCount--;
    }
}
