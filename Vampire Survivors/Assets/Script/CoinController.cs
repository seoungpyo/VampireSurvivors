using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : SingletonMonobehavior<CoinController>
{
    [HideInInspector] public int currentCoins;
    
    public CoinPickUp coin;

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;

        UIController.Instance.UpdateCoins();
    }

    public void DropCoin(Vector3 position, int value)
    {
        CoinPickUp newCoin = Instantiate(coin, position + new Vector3(0.2f, 0.1f, 0f), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }

}
