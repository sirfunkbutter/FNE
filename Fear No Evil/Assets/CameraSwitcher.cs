using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    public Camera FirstPerson;
    public Camera MiniMap;
    public Camera Map;
	void Start () {
        FirstPerson.enabled = true;
        MiniMap.enabled = true;
        Map.enabled = false;
    }
	void Update () {
        //if (Input.GetKey(KeyCode.M)){
        //    MiniMap.transform.
        //}
	}
}
