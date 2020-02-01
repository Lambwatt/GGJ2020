using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools {

    public static Vector3 RandomDirection(){
        return Rotate(Vector3.right, Random.Range(0.0f,360.0f));
    }

    public static Vector3 RandomDirection(Vector3 vector, float minAngle, float maxAngle)
    {
        return Rotate(vector, (Random.Range(minAngle, maxAngle) * (Random.Range(0, 2) == 0 ? 1 : -1)));
    }

    public static Vector3 Rotate(Vector3 vec, float angle)
    {
        angle *= Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle) * vec.x - Mathf.Sin(angle) * vec.y,
                          Mathf.Sin(angle) * vec.x + Mathf.Cos(angle) * vec.y);
    }
}
