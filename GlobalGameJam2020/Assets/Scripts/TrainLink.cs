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
        Vector3 dir = (LinkBeyond.transform.position - NextLink.transform.position).normalized;
        float angle = Mathf.Deg2Rad * (Random.Range(10.0f, 80.0f) * (Random.Range(0, 2) == 0 ? 1 : -1));
        dir = new Vector3(Mathf.Cos(angle) * dir.x - Mathf.Sin(angle) * dir.y,
                          Mathf.Sin(angle) * dir.x + Mathf.Cos(angle) * dir.y);
        dir *= Random.Range(5, 15);

        TrainLink link = Instantiate(LinkPrefab, LinkBeyond.transform.position + dir, Quaternion.identity);
        NextLink.LinkBeyond = link;
        LinkBeyond.NextLink = link;

        Active = false;
    }
}
