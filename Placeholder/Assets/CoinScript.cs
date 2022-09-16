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
        Debug.Log(coins);
        coinsText.text = "Coins: " + coins;
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
