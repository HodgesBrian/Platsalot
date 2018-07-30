using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landState : MonoBehaviour {
     GameObject player;
    public float tracking = 0f;


    // Use this for initialization
    void Start () {
        Time.fixedDeltaTime = 0.25f;
        player = gameObject;
	}
	
	// start of youtube reference link https://youtu.be/VBZFYGWvm4A
	private void Update () {

            Vector3 mouseToWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
            Vector3 mp = Camera.main.ScreenToWorldPoint(mouseToWorld);
        Vector2 mousPosition = Input.mousePosition;
        Vector2 characterScreen = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offSet = mousPosition - characterScreen;
        float angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle + 90, 0);
            //Debug.DrawRay(transform.position, mp, Color.green);

        if (Input.GetMouseButtonDown  (0)) 
		{
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			
                foreach(RaycastHit h in Physics.RaycastAll(ray))
            { 
                    //if (Physics.Raycast(ray, out hitInfo))
                    //{
                GameObject g = h.transform.gameObject;
                if (Vector3.Distance(player.transform.position, h.point) < 20)
                {
                    //PlaceCubeNear (hitInfo.point);
                    if (h.transform.GetComponent<TileManager>())
                    {
                        if (g.GetComponentInChildren<PlantManager>())
                        {
                            //Debug.Log("IM TRYING TO RESET THE PLANT GROWTH!");
                            PlantManager plant = g.GetComponentInChildren<PlantManager>();
                            
                                plant.plantReset();
                        }
                        h.transform.GetComponent<TileManager>().setState(g.GetComponent<TileManager>().getState() + 1);
                        tracking++;
                        //Debug.Log("THIS IS FUCKING TRACKING: " + tracking);
                        
                    }
                    //else
                    //{
                    //    hitInfo.transform.gameObject.GetComponentInParent<TileManager>().setState(g.GetComponentInParent<TileManager>().getState() + 1);
                    //    if (g.GetComponent<PlantManager>())
                    //    {
                    //        Debug.Log("IM TRYING TO RESET THE PLANT GROWTH!");
                    //        PlantManager plant = g.GetComponentInChildren<PlantManager>();
                    //        if (plant.currentState == 3)
                    //            plant.plantReset();
                    //    }
                    //    else
                    //    {
                    //        Debug.Log("IM TRYING TO RESET THE PLANT GROWTH!");
                    //        PlantManager plant = g.GetComponentInChildren<PlantManager>();
                    //        if (plant.currentState == 3)
                    //            plant.plantReset();
                    //    }
                        //Debug.Log(hitInfo.transform.gameObject.name);
                    }
                    //if (g.GetComponent<PlantManager>())
                    //{
                    //    Debug.Log("IM TRYING TO RESET THE PLANT GROWTH!");
                    //    PlantManager plant = g.GetComponentInChildren<PlantManager>();
                    //    if (plant.currentState == 3)
                    //          plant.plantReset();
                    //}
                }
                
            }
		}
        
	//}

	private void PlaceCubeNear(Vector3 clickPoint)
	{
		var finalPosition = gameObject.GetComponent<landBuilder>().GetNearestPointOnGrid (clickPoint);
		GameObject.CreatePrimitive (PrimitiveType.Cube).transform.position = finalPosition;
		//GameObject[] Seeds = new GameObject[2];

	}
    
	// end of youtube reference.
}
