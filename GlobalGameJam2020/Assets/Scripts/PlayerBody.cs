using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBody : MonoBehaviour {

    public int HP = 3;
    public Text HPText;
    public string HPHeader = "HP: ";

    int Score = 0;
    public Text ScoreText;
    public string ScoreHeader = "Score: ";

	// Use this for initialization
	void Start () {
        UpdateHP();
        UpdateScore();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        string val = collision.tag;
        if(val == "Rock"){
            
            HP--;
            UpdateHP();
            if(HP<=0){
                Die();
            }
        }
	}

    public void AddToScore(int points){
        Score += points;
        UpdateScore();
    }

    void UpdateScore(){
        ScoreText.text = ScoreHeader + Score;
    }

    void UpdateHP(){
        HPText.text = HPHeader + HP;
    }

    private void Die(){
        SceneManager.LoadScene("EndScreen");
    }
}
