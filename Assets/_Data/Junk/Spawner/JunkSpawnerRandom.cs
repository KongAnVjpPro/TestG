using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkSpawnerRandom : AnMonoBehaviour
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float timeDelay = 1f;
    [SerializeField] protected float randomLimit = 9f;
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " : Load JunkSpawner", gameObject);
    }

    // protected override void Start()
    // {
    //     this.JunkSpawning();
    // }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeDelay) return;
        this.timer = 0f;

        Transform randomPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom();

        Vector3 pos = randomPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);


        //Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
