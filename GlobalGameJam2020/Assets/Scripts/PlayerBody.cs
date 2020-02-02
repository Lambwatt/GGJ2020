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

    public AudioSource Source;

    public AudioClip[] GetHit;
    public AudioClip[] Explosions;

    public Animator Animator;

    public FollowPlayer Camera;

    public GameObject grabRegion;

    int TrainCount = 0;
    bool alive = true;

	// Use this for initialization
	void Start () {
        UpdateHP();
        UpdateScore();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (alive)
        {
            string val = collision.tag;
            if (val == "Rock")
            {
                HP--;
                UpdateHP();
                if (HP <= 0)
                {
                    Die();
                }
                else
                {
                    Source.PlayOneShot(GetHit[Random.Range(0, GetHit.Length)]);
                }
            }
        }
	}

    public bool IsAlive(){
        return alive;
    }

    public void AddToScore(int points){
        if (alive)
        {
            Score += points;
            UpdateScore();
        }
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
            DieByTrain();
        }
    }

    private void Die(){
        grabRegion.SetActive(false);
        alive = false;
        PlayerPrefs.SetInt("ActiveScore", Score);
        StartCoroutine(HandleDeath());
    }

    private void DieByTrain(){
        grabRegion.SetActive(false);
        alive = false;
        PlayerPrefs.SetInt("ActiveScore", Score);
        Camera.ShowDeathByTrain();
        StartCoroutine(HandleDeathByTrain());
    }

    IEnumerator HandleDeathByTrain()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("EndScreen");
    }

    IEnumerator HandleDeath()
    {
        Animator.SetTrigger("Die");
        Source.PlayOneShot(Explosions[Random.Range(0, Explosions.Length)]);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EndScreen"); 
    }
}
