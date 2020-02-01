﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRegion : MonoBehaviour {

    public SpriteRenderer Image;

    List<Grabbable> GrabbedStuff;

	private void Start()
	{
        GrabbedStuff = new List<Grabbable>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
        
        string val = collision.tag;
        Debug.Log("Collided with "+val+"!");
        if (val == "Pair")
        {
            //check if pair matches an element in the list
            TrackPair pair = collision.GetComponent<TrackPair>();

            if(pair.Damaged && GrabbedStuff.Count>0){
                pair.Repair();
                Destroy(GrabbedStuff[0].gameObject);
                GrabbedStuff.RemoveAt(0);
            }
        }
        else if(val == "Grabbable")
        {
            collision.transform.SetParent(transform);
            GrabbedStuff.Add(collision.GetComponent<Grabbable>());
            //if On Add to list
            //otherwise don't
        }
        else if(val == "Rock")
        {
            //Shatter?
        }
	}

    //Grabbable HasPiece()
}
