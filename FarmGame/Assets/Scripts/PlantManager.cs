using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

    public float plantTimeCount = 5;
    public float plantGrowth;
    public int currentState = 0;
    
	// Use this for initialiation
	void Start () {

        plantGrowth = plantTimeCount;
	    
	}
	
	// Update is called once per frame
	void Update () {


        if (currentState < transform.childCount)
        {
            plantGrowth = plantGrowth - Time.deltaTime;
           // Debug.Log("The Current State is " + currentState);
           // Debug.Log("Plant in T -- " + plantGrowth);

            if (plantGrowth <= 0)
            {
                if (currentState == transform.childCount)
                {

                }
                else
                {
                    currentState++;
                    for (int x = 0; x < transform.childCount; x++)
                    {
                        transform.GetChild(x).gameObject.SetActive(false);
                    }
                    transform.GetChild(currentState - 1).gameObject.SetActive(true);
					//Debug.Log ("This is the CURRENT STATE: " + currentState );
                }
                plantGrowth = plantTimeCount;
            }
        }
	}

    public void plantReset()
    {
        currentState = 1;
        for (int x = 0; x < transform.childCount; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
        transform.GetChild(currentState - 1).gameObject.SetActive(true);
        Debug.Log("The Plant Has Been Harvested.");
    }
}
