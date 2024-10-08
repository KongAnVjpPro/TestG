using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.1f;
    [SerializeField] protected float shootTimer = 0;

    void Update()
    {
        this.IsShooting();

    }
    void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer <= this.shootDelay) return;
        this.shootTimer = 0;


        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        // Transform newBullet2 = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo, spawnPos, rotation);
        // Transform newBullet3 = BulletSpawner.Instance.Spawn(BulletSpawner.bulletThree, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
        // newBullet2.gameObject.SetActive(true);
        // newBullet3.gameObject.SetActive(true);

    }

    protected virtual bool IsShooting()
    {
        this.isShooting = (InputManager.Instance.OnFiring == 1);
        return this.isShooting;
    }
}
