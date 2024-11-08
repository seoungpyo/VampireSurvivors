using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Weapon activeWeapon;

    private Player player;
    private float moveSpeed;

    private void Awake()
    {

        instance = this;

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
