using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brian Hodges
//4-13-18
//Team Production 1
//Programming lead: Blake
//FarmGame

public class landBuilder : MonoBehaviour {

	GameObject land;
    GameObject[] grid;
    public GameObject parent;//the ground element
    //int gridArrySize; // this gets the overall size, 
    //for example lanGridX = 25, landGridZ = 25, 
    //the grid array size would need to be 625 because, 25 * 25 = 625.

    public int landGridX = 3;// this gets the starts the row
	public int landGridZ = 3;// this is the length of the row


	//GameObject landClone;

	// Use this for initialization
	void Start () 
	{
        land = transform.GetChild(0).gameObject;
        
        //gridArrySize = landGridZ * landGridZ;
        grid = new GameObject[landGridX * landGridZ]; //gound array of elements
		Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
		int count = 0;

		if (count != -1)//Initializes
		{
			for (int i = 0; i < landGridX; i++) //this creates the grid going down. Hight
			{
				for (int j = 0; j < landGridZ; j++) //this creates the grid going right. Width
				{
					grid [count] = Instantiate (land, pos, Quaternion.identity, parent.transform) as GameObject; // This creates the landOBJ.
					pos.z += 1.0f; // sets each land squares position on z.
					count++;// this counts the gridArrySize on each pass. Not important, but usful for debuging.
					//Debug.Log ("Land should be working: " + count + " " + i + " " + j);//testing, comment out when done.
				}

				pos.x += 1.0f;// sets each land square on x.
				pos.z = 0.0f;// This resets the width to create a new row under the previous. if this isnt reset it will starecase.
				//Debug.Log (" i is working: " + i);//testing, comment out when done.
			}
		}
	}


	// start of youtube reference link https://youtu.be/VBZFYGWvm4A
	private float size = 1f;
	public float Size {get{ return size;}}

	public Vector3 GetNearestPointOnGrid(Vector3 position)
	{
		position -= transform.position;

		int xCount = Mathf.RoundToInt (position.x / size);
		int yCount = Mathf.RoundToInt (position.y / size);
		int zCount = Mathf.RoundToInt (position.z / size);

		Vector3 result = new Vector3 (
			                 (float)xCount * size,
			                 (float)yCount * size,
			                 (float)zCount * size);
		result += transform.position;

		return result;
	}

    private void OnDrawGizmos()//this creates yellow clickable spheres.
	{
		Gizmos.color = Color.yellow;
		for (float x = 0; x < landGridX; x += size) //scales with the size of the grid
		{
			for (float z = 0; z < landGridZ; z += size) //scales with the size of the grid
            {
				var point = GetNearestPointOnGrid (new Vector3 (x, 0.0f,z));
				Gizmos.DrawSphere (point, 0.1f);
			}
		}
	}
	// End youtube reference.

	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    for (int x = 0; x < grid.Length; x++)
        //    {
        //        grid[x].GetComponent<TileManager>().setState(1);
        //        Debug.Log(grid[x].name);
        //    }
        //}
	}
}
