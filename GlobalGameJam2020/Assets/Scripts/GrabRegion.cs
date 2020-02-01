using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRegion : MonoBehaviour {

    public SpriteRenderer Image;

    List<Grabbable> GrabbedStuff;

	void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("Collided!");
        string val = collision.tag;

        if (val == "Pair")
        {
            //check if pair matches an element in the list
        }
        else if(val == "Grabbable")
        {
            collision.transform.SetParent(transform);
            //if On Add to list
            //otherwise don't
        }
        else if(val == "Rock")
        {
            //Shatter?
        }
	}
}
