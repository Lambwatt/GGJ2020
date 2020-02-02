using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRegion : MonoBehaviour {

    public SpriteRenderer Image;
    public Spawner Spawner;
    public PlayerBody ScoreManager;
    public int FixPairValue = 5;
    public int PickUpValue = 1;
    public InventoryDisplay Display;

    List<Grabbable> GrabbedStuff;

	private void Start()
	{
        GrabbedStuff = new List<Grabbable>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
        
        string val = collision.tag;
        //Debug.Log("Collided with "+val+"!");
        if (val == "Pair")
        {
            //check if pair matches an element in the list
            TrackPair pair = collision.GetComponent<TrackPair>();
            if (pair.Damaged)
            {
                for (int i = 0; i < GrabbedStuff.Count; i++)
                {
                    if (GrabbedStuff[i].PairType == pair.ActiveType)
                    {
                        pair.Repair();
                        Display.Remove(GrabbedStuff[i].GetComponent<SpriteRenderer>().sprite);
                        Spawner.ActivateSpawner();
                        Spawner.StopTracking(GrabbedStuff[i].transform);
                        Destroy(GrabbedStuff[i].gameObject);
                        GrabbedStuff.RemoveAt(i);
                        ScoreManager.AddToScore(FixPairValue);
                        break;
                    }
                }
            }

            //if(pair.Damaged && GrabbedStuff.Count>0){
            //    pair.Repair();
            //    Spawner.ActivateSpawner();
            //    Spawner.StopTracking(GrabbedStuff[0].transform);
            //    Destroy(GrabbedStuff[0].gameObject);
            //    GrabbedStuff.RemoveAt(0);
            //    ScoreManager.AddToScore(FixPairValue);
            //}
        }
        else if(val == "Grabbable")
        {
            collision.transform.SetParent(transform);
            GrabbedStuff.Add(collision.GetComponent<Grabbable>());
            collision.GetComponent<SpaceObject>().Stop();
            ScoreManager.AddToScore(PickUpValue);
            Display.PickUp(collision.GetComponent<SpriteRenderer>().sprite);
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
