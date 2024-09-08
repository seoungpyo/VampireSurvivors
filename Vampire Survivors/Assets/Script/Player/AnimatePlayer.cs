using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class AnimatePlayer : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        player.movementByVelocityEvent.OnMovementToVelocity += MovementByVelocityEvent_OnMovementByVelocity;

        player.idleEvent.OnIdle += IdleEvent_OnIdle;
    }

    private void OnDisable()
    {
        player.movementByVelocityEvent.OnMovementToVelocity -= MovementByVelocityEvent_OnMovementByVelocity;

        player.idleEvent.OnIdle -= IdleEvent_OnIdle;
    }

    private void MovementByVelocityEvent_OnMovementByVelocity(MovementByVelocityEvent movementByVelocityEvent, MovementByVelocityEventArgs movementByVelocityEventArgs)
    {
        player.animator.SetBool("isMove", true);
    }

    private void IdleEvent_OnIdle(IdleEvent idleEvent)
    {
        player.animator.SetBool("isMove", false);
    }

}

