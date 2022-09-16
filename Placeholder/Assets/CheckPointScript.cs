using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    HealthScript healthScript;
    private void OnTriggerEnter(Collider other)
    {
        healthScript = other.transform.gameObject.GetComponent<HealthScript>();
        healthScript.SaveCheckpoint(this.transform.position);
        return;
    }

}
