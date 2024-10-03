using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class AnimatePlayer : MonoBehaviour
{
    private Player player;
    private MovementByVelocityEvent movementByVelocityEvent;
    private IdleEvent idleEvent;


    private void Awake()
    {
        player = GetComponent<Player>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        idleEvent = GetComponent<IdleEvent>();
    }

    private void OnEnable()
    {
        movementByVelocityEvent.OnMovementToVelocity += MovementByVelocityEvent_OnMovementByVelocity;

        idleEvent.OnIdle += IdleEvent_OnIdle;
    }

    private void OnDisable()
    {
        movementByVelocityEvent.OnMovementToVelocity -= MovementByVelocityEvent_OnMovementByVelocity;

        idleEvent.OnIdle -= IdleEvent_OnIdle;
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

