using System;
using UnityEngine;

public class HandleMovement : Singleton<HandleMovement>
{
    public event Action<Vector2> OnMovement;

    private void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        if (TryGetComponent(out Joystick joystick))
        {
            OnMovement?.Invoke(joystick.Direction);
        }        
    }
}
