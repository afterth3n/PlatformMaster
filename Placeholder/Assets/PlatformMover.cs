using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    Vector3 pos1 = new Vector3(-115f, 72.5f, 92f);
    Vector3 pos2 = new Vector3(-115f, 72.5f, 70f);
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
            transform.position = Vector3.MoveTowards(transform.position, pos1, 12f * Time.deltaTime);
            if(Vector3.Distance(transform.position, pos1) < 1)
            {
                check = true;
            }
        }
        if(check)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2, 12f * Time.deltaTime);
            if(Vector3.Distance(transform.position, pos2) < 1)
            {
                check = false;
            }
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.SetParent(gameObject.transform, true);
    }
    void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.parent = null;
    }
}
