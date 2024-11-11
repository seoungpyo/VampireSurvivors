using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public List<Weapon> unassignedWeapons;
    public List<Weapon> assignedWeapons;

    private Player player;
    private float moveSpeed;

    public int maxWeapons = 3;

    [HideInInspector] public List<Weapon> fullyLevelledWeapon = new List<Weapon>();

    private void Awake()
    {

        instance = this;

        player = GetComponent<Player>();

        moveSpeed = player.playerDetails.moveSpeed;
    }

    private void Start()
    {
        AddWeapon(Random.Range(0, assignedWeapons.Count));
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

    public void AddWeapon(int weaponNumber)
    {
        if(weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);

            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }
    
    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);

        assignedWeapons.Add(weaponToAdd);

        unassignedWeapons.Remove(weaponToAdd);
    }
}
