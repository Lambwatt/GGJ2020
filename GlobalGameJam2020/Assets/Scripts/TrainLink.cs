using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLink : MonoBehaviour {

    public TrainLink NextLink;

    public void SetNextDirection(Train train){
        Vector3 dir = (NextLink.transform.position - transform.position).normalized;
        train.transform.position = transform.position;
        train.transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
        train.Rb.velocity = dir * train.Speed;
    }
}
