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

    int TrainCount = 0;

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

    public void AddTrain(){
        TrainCount += 1;
    }

    public void LoseTrain(){
        TrainCount -= 1;
        Debug.Log("Train Lost. Down to "+TrainCount);
        if(TrainCount<=0){
            Die();
        }
    }

    private void Die(){
        PlayerPrefs.SetInt("ActiveScore", Score);
        SceneManager.LoadScene("EndScreen");
    }
}
