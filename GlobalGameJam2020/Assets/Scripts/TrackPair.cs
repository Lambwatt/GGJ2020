using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPair : MonoBehaviour {
    
    public bool Damaged;
    public bool Fixed = false;
    public SpriteRenderer[] Parts;


	// Use this for initialization
	void Start () {
        //Initialize();
	}

    public void Initialize(bool damaged = false)
    {
        Damaged = damaged;
        if (Damaged)
        {
            int choice = Random.Range(0, Parts.Length);
            Parts[choice].color = Color.black;
        }
    }

    public void Repair(){
        Damaged = false;
        Fixed = true;
        for (int i = 0; i < Parts.Length; i++){
            Parts[i].color = Color.white;
        }
    }

}
