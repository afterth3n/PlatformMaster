using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public Vector3 checkpoint;

    void Start()
    {
        checkpoint = new Vector3(0f,0f,0f);
    }

    public void SaveCheckpoint(Vector3 current)
    {
        checkpoint = current;
        Debug.Log(checkpoint);
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        return;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(checkpoint.x != 0f && checkpoint.y != 0f && checkpoint.z != 0f)
            {
                this.transform.position = checkpoint;
            }
        }
    }

}
