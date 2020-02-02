using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D Rb;
    public float Speed;

    public GameObject ThrusterSprites;

	// Use this for initialization
	void Start () {
        ThrusterSprites.SetActive(false);
	}
	
    // Update is called once per frame
    void Update()
    {
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
        
        Rb.velocity = velocity * Speed;
        if (velocity.magnitude > 0.9f)
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.right, velocity);
            ThrusterSprites.SetActive(true);
        }else{
            ThrusterSprites.SetActive(false);
        }
    }

}
