using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkRandom : AnMonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " : Load JunkSpawner", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        Transform randomPoint = this.junkCtrl.junkSpawnPoints.GetRandom();

        Vector3 pos = randomPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkCtrl.junkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);


        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
