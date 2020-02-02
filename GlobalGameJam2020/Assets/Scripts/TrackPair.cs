using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPair : MonoBehaviour {
    
    public bool Damaged;
    public bool Fixed = false;
    public SpriteRenderer[] Parts;

    public Color FixedColor;
    public Color DamagedColor;

    public SpriteRenderer[] Rails;

    public Sprite WorkingRail;
    public Sprite BrokenRail;

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
            Parts[choice].color = DamagedColor;
        }
    }

    public void Repair(bool fix = true){
        Damaged = false;
        Fixed = fix;
        for (int i = 0; i < Parts.Length; i++){
            Parts[i].color = FixedColor;
        }
    }

}
