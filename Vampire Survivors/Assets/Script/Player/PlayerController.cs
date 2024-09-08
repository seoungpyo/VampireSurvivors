using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour
{
    private Player player;
    private float moveSpeed;

    private void Awake()
    {
        player = GetComponent<Player>();

        moveSpeed = player.playerDetails.moveSpeed;
    }

    private void Update()
    {
        MoveInput();
    }

    private void MoveInput()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontalMovement, verticalMovement);

        if (horizontalMovement != 0 & verticalMovement != 0)
        {
            moveDirection.Normalize();
        }

        player.movementByVelocityEvent.CallMovementToVelocityEvent(moveDirection, moveSpeed);

        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            player.idleEvent.CallIdleEvent();
        }
    }
}
