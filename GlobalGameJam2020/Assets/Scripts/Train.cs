using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public float StartDelay = 1.0f;
    public Rigidbody2D Rb;
    public float Speed = 0.01f;
    public int HP = 3;

    public int TravelledPairValue = 10;
    public PlayerBody Player;

    public AudioSource Source;
    public AudioClip[] SkipSounds;
    public AudioClip[] ExplosionSounds;

    bool dead = false;

	private void Start()
	{
        Player.AddTrain();
        StartCoroutine(WaitThenStart());
	}

	IEnumerator WaitThenStart()
    {
        while(StartDelay>0){
            StartDelay -= Time.deltaTime;
            yield return null;
        }
//        Debug.Log("Start");
        Rb.velocity = new Vector2(1.0f, 0.0f) * Speed;
        //Debug.Log(Rb.velocity);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (dead) return;
        
        string val = collision.tag;

        if(val == "Pair")
        {
            //if complete live
            //else take damage and maybe die
            TrackPair pair = collision.GetComponent<TrackPair>();
            if(pair.Damaged){
                Rb.velocity = Tools.RandomDirection(Rb.velocity, 10.0f, 100.0f);
                //float angle = Mathf.Deg2Rad * (Random.Range(10.0f, 100.0f) * (Random.Range(0, 2) == 0 ? 1 : -1));
                //Rb.velocity = new Vector2(Mathf.Cos(angle) * Rb.velocity.x - Mathf.Sin(angle) * Rb.velocity.y,
                                          //Mathf.Sin(angle) * Rb.velocity.x + Mathf.Cos(angle) * Rb.velocity.y);
                Rb.velocity *= 0.75f;
                pair.Repair(false);
                Source.PlayOneShot(SkipSounds[Random.Range(0, SkipSounds.Length)]);
                Player.LoseTrain();
            }else{
                if (pair.Fixed)
                {
                    Player.AddToScore(TravelledPairValue);
                }
            }

        }
        else if(val == "Link")
        {
            //Get new destinaiton
            collision.GetComponent<TrainLink>().SetNextDirection(this);
        }
	}

    void Die(){
        StartCoroutine(HandleExplosion());
    }

    IEnumerator HandleExplosion()
    {
        
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
