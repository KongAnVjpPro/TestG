using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed = 0.1f;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get mouse position
        this.worldPosition.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.speed);//start to end in speed sec
        transform.position = newPos;
    }
}
