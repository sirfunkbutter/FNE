using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter : MonoBehaviour {
    public GameObject blocker;

   /* void OnTriggerEnter(Collider other)
    {
    }*/
    void OnTriggerExit(Collider other)
    {
        blocker.transform.position = this.transform.position;
    }
}
