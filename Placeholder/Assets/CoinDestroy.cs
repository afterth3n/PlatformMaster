using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    CoinScript coinScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !other.isTrigger)
        {
            coinScript = other.gameObject.GetComponent<CoinScript>();
            coinScript.AddCoin(1);
            Destroy(gameObject);
        }
    }

}
