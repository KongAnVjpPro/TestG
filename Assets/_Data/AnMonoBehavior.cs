using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnMonoBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();//if comps > 0 return
    }
    protected virtual void LoadComponents()
    {
        //override something
    }
}
