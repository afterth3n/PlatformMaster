using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    int coins = 0;
    public Text coinsText;
    public void AddCoin(int amount)
    {
        coins += amount;
        coinsText.text = "Coins: " + coins;
        return;
    }

    public int CheckCoins()
    {
        return coins;
    }
}
