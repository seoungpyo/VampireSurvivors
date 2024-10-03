using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehavior<GameManager>
{

    public Player player; 

    protected override void Awake()
    {
        base.Awake();

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

}
