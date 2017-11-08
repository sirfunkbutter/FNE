/*using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    float view = Input.GetAxis("Mouse Y");
    private Vector3 CameraPan;
    private Vector3 cam;
    private Transform m_Cam;

    void Start()
    {
        m_Cam = this.transform;
    }

    void Update()
    {
        cam = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
        CameraPan = view * cam + m_Cam.right;
        
    }
}*/


using UnityEngine;
using System.Collections;

public class MiniMapCamera : MonoBehaviour {

	public Transform player;
	Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
		//transform.position = player.transform.position;
		//transform.position.y = player.transform.position.y + 2;
	}

	void Update ()
	{
		transform.position = player.transform.position + offset;
		//transform.rotation = player.transform.rotation;
		//transform.LookAt(player);
	}
}


/*

using UnityEngine; using System.Collections;
 public class camera : MonoBehaviour {
	 public Transform ThirdPerson;
	 public Transform FirstPerson;
     public float Speed = 10;
	 var first : boolean = true;
     void Start(){
	 	transform.position = ThirdPerson.transform.position;
	 }
	 void Update () {
         while(first){
			transform.position = FirstPerson.transform.position;
			if (Input.GetKeyDown("tab")){
			 	first = false;
			 }
		 }
		 while(!first){
		 	transform.position = ThirdPerson.transform.position;
			 if (Input.GetKeyDown("tab")){
			 	first = true;
			 }
		 }
     }
} */
