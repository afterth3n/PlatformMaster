using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour
{
    CoinScript coinScript;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinScript = other.gameObject.GetComponent<CoinScript>();
            
            if (Input.GetKeyDown(KeyCode.E) && coinScript.CheckCoins() >= 8)
            {
                Destroy(gameObject);
            }
        }
    }
}
