using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : AnMonoBehaviour
{
    public JunkSpawner junkSpawner;
    public JunkSpawnPoints junkSpawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + " : Load JunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        this.junkSpawnPoints = Transform.FindAnyObjectByType<JunkSpawnPoints>();
        Debug.Log(transform.name + " : Load JunkSpawnPoints", gameObject);
    }


}
