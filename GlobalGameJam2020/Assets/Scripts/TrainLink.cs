using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLink : MonoBehaviour {

    public int linkIntervalMin = 5;
    public int linkIntervalMax = 15;

    public TrainLink NextLink;
    public TrainLink LinkBeyond;

    public TrackPair Rail;
    public TrainLink LinkPrefab;

    public bool Active = true;



    public void SetNextDirection(Train train)
    {
        Vector3 dir = (NextLink.transform.position - transform.position).normalized;
        train.transform.position = transform.position;
        train.transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
        train.Rb.velocity = dir * train.Speed;

        if(Active)
            ExtendTrack();
    }

    public void ExtendTrack()
    {
        //Calculate destination
        Vector3 dir = (LinkBeyond.transform.position - NextLink.transform.position).normalized;
        dir = Tools.RandomDirection(dir, 10.0f, 80.0f);
        //float angle = Mathf.Deg2Rad * (Random.Range(10.0f, 80.0f) * (Random.Range(0, 2) == 0 ? 1 : -1));
        //dir = new Vector3(Mathf.Cos(angle) * dir.x - Mathf.Sin(angle) * dir.y,
                          //Mathf.Sin(angle) * dir.x + Mathf.Cos(angle) * dir.y);
        int distance = Random.Range(5, 15);
        //dir *= distance;

        //place link
        TrainLink link = Instantiate(LinkPrefab, LinkBeyond.transform.position + dir*distance, Quaternion.identity);
        NextLink.LinkBeyond = link;
        LinkBeyond.NextLink = link;



        //place tracks
        TrackPair trackPair;
        Quaternion trackAngle = Quaternion.FromToRotation(Vector3.right, dir);
        for (int i = 1; i < distance; i++){
            trackPair = Instantiate(Rail, LinkBeyond.transform.position + dir * i, trackAngle);
            trackPair.Initialize(Random.Range(0,4)==0);
        }


        //prevent multiple activation
        Active = false;
    }
}
