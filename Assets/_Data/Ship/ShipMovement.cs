using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z);
    }
    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPosition;//get mouse position
        this.targetPosition.z = 0;
    }
    protected virtual void Moving()
    {

        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);//start to end in speed sec
        transform.parent.position = newPos;
    }
}
