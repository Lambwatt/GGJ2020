using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D Rb;
    public float Speed;

    public GameObject ThrusterSprites;
    public PlayerBody body;

    //public AudioSource Thrust;

	// Use this for initialization
	void Start () {
        ThrusterSprites.SetActive(false);
	}
	
    // Update is called once per frame
    void Update()
    {
        if (body.IsAlive())
        {
            Vector2 velocity = new Vector2();
            bool ShowThrust = false;
            if (Input.GetKey(KeyCode.A))
            {
                velocity += new Vector2(-1, 0);
                ShowThrust = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                velocity += new Vector2(0, 1);
                ShowThrust = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                velocity += new Vector2(0, -1);
                ShowThrust = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                velocity += new Vector2(1, 0);
                ShowThrust = true;
            }

            Rb.velocity = velocity * Speed;
            if (ShowThrust)
            {
                transform.rotation = Quaternion.FromToRotation(Vector2.right, velocity);
                ThrusterSprites.SetActive(true);
                //Thrust.Play();
            }
            else
            {
                ThrusterSprites.SetActive(false);
                //Thrust.Stop();
            }
        }else{
            Rb.velocity = new Vector2(0, 0);
            ThrusterSprites.SetActive(false);
        }
    }
}
