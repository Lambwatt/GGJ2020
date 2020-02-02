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

    public string[] PairTypes;
    public Sprite[] PairSprites;

    public string ActiveType;

	// Use this for initialization
	void Start () {
        //Initialize();
	}

    public void Initialize(bool damaged = false)
    {
        int typeChoice = Random.Range(0, PairTypes.Length);
        ActiveType = PairTypes[typeChoice];

        Parts[0].sprite = PairSprites[typeChoice];
        Parts[1].sprite = PairSprites[typeChoice];

        Damaged = damaged;
        if (Damaged)
        {
            int choice = Random.Range(0, Parts.Length);
            Parts[choice].color = DamagedColor;
            Rails[choice].sprite = BrokenRail;
        }
    }

    public void Repair(bool fix = true){
        Damaged = false;
        Fixed = fix;
        for (int i = 0; i < Parts.Length; i++){
            Parts[i].color = FixedColor;
            Rails[i].sprite = WorkingRail;
        }
    }

}
