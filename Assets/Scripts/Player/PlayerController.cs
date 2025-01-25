using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public event Action Pressed;
    public event Action Released;
    public event Action PressedRMB;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Pressed?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Released?.Invoke();
        }

        if(Input.GetMouseButtonDown(1))
        {
            PressedRMB?.Invoke();
        }
    }
}