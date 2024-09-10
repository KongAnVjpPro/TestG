using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance { get => instance;/* set => instance = value*/}
    protected Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition { get => mouseWorldPosition; }


    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
