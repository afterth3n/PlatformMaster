using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    Vector3 pos1 = new Vector3(-f, f, f);
    Vector3 pos2 = new Vector3(-118f, 72.5f, 70f);
    bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!check)
        {
            transform.position = Vector3.Lerp(pos2, pos1, 5f);
            if(Vector3.Distance(transform.position, pos1) < 1)
            {
                check = true;
            }
        }
    }
}
