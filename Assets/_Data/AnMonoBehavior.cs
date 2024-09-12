using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Start()
    {

    }
    protected virtual void Awake()
    {
        this.LoadComponents();//if comps > 0 return
    }
    protected virtual void LoadComponents()
    {
        //override something
    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void OnEnable()
    {

    }
}
