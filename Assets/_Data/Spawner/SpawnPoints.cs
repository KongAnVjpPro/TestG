using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : AnMonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoints;

    // protected override void Awake()
    // {
    //     base.Awake();
    // }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count != 0) return;
        foreach (Transform point in transform)
        {
            this.spawnPoints.Add(point);
        }
        Debug.Log(transform.name + " : Load SpawnPoints ", gameObject.transform);
    }
    public Transform GetRandom()
    {
        int randomNum = Random.Range(0, this.spawnPoints.Count - 1);
        return this.spawnPoints[randomNum];
    }
}
