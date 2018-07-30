using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public int state = 0;
	// Use this for initialization
	void Start () {

        transform.GetChild(0).gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		    
	}
    public void setState(int s)
    {
        state = s;
		if(state >= transform.GetChildCount())
		{
			state = 1;
		}
        for(int x = 0; x < transform.GetChildCount(); x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
        transform.GetChild(state).gameObject.SetActive(true);
        
    }
    private void OnMouseDown()
    {
        //setState(1);
		//if(transform.GetChild(state) == transform.GetChildCount())
		//{
		//	state = 0;
		//}
    }
    public int getState()
    {
        //Debug.Log("The PUBLIC state is " + state);
        return state;
    }

}
