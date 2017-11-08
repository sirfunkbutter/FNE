using UnityEngine;
using System.Collections;

public class FPS_Time : MonoBehaviour {
	// Use this for initialization
	Vector3 rotationVector;
	void Start () {
		rotationVector = transform.rotation.eulerAngles;
   		transform.rotation = Quaternion.Euler(rotationVector);
	}
	
	// Update is called once per frame
	void Update () {
		rotationVector.x -= (float) .05;
		transform.rotation = Quaternion.Euler(rotationVector);
	}
}
