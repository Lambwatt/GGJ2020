using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D Rb;
    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = new Vector2();

        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector2(-1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector2(0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector2(0, -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector2(1, 0);
        }

        transform.rotation = Quaternion.FromToRotation(Vector2.right, velocity);
        Rb.velocity = velocity * Speed;
	}


}
