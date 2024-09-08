using System;
using UnityEngine;

public class MovementByVelocityEvent : MonoBehaviour
{
    public event Action<MovementByVelocityEvent, MovementByVelocityEventArgs> OnMovementToVelocity;

    public void CallMovementToVelocityEvent(Vector2 moveDirection, float moveSpeed)
    {
        OnMovementToVelocity?.Invoke(this, new MovementByVelocityEventArgs() { moveDirection = moveDirection, moveSpeed = moveSpeed });
    }
}

public class MovementByVelocityEventArgs : EventArgs
{
    public Vector2 moveDirection;
    public float moveSpeed;
}

