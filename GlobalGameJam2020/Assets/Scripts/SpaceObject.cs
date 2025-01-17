﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour {

    public Rigidbody2D Rb;

    public float MinSpeed = 1;
    public float MaxSpeed = 5;

    public bool NeverMove = false;

	// Use this for initialization
	void Start () {
        if(!NeverMove)
            Rb.velocity = Tools.RandomDirection() * Random.Range(MinSpeed, MaxSpeed);
	}

    public void Stop(){
        Rb.velocity = new Vector2(0, 0);
        Rb.simulated = false;
       //x Debug.Log(Rb.velocity);
    }
}
