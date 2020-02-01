using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScoreHandler : MonoBehaviour {

    public Text Score;

	// Use this for initialization
	void Start () {
        Score.text = ""+PlayerPrefs.GetInt("ActiveScore");
	}
}
