using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

    public float moveSpeed = 8.0f;// if this doesnt change your speed, check Unity inspector and chage it there.
    public GameObject playerHolding;

    //public var mouse_pos : Vector3;
    //public var target : Transform; //Assign to the object you want to rotate
    //public var object_pos : Vector3;
    //public var angle : float;
 


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("YOUR SPEED IS:" + moveSpeed);
		if (Input.GetKey ("w")) 
		{
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime );
		}
		if (Input.GetKey ("a")) 
		{
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey ("s")) 
		{
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey ("d")) 
		{
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		}

        // var mouse = Input.mousePosition;
        // Vector3 screenPoint = Camera.main.ScreenToWorldPoint(playerHolding.transform.localPosition);
        // var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        // var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg * 3;
        // playerHolding.transform.rotation = Quaternion.Euler(0, -angle, 0);

        //gameObject.transform.LookAt(screenPoint);
        //Vector3 rot = gameObject.transform.eulerAngles;
        //rot.x = 0;
        //rot.z = 0;
        //gameObject.transform.eulerAngles = rot;


        //Camera.main.ScreenToWorldPoint

    }
 
 //void function Update()
 //   {
 //       mouse_pos = Input.mousePosition;
 //       mouse_pos.z = 5.23; //The distance between the camera and object
 //       object_pos = Camera.main.WorldToScreenPoint(target.position);
 //       mouse_pos.x = mouse_pos.x - object_pos.x;
 //       mouse_pos.y = mouse_pos.y - object_pos.y;
 //       angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
 //       transform.rotation = Quaternion.Euler(Vector3(0, 0, angle));
 //   }
}
