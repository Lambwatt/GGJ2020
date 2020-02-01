using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public float StartDelay = 1.0f;
    public Rigidbody2D Rb;
    public float Speed = 0.01f;
    public int HP = 3;

	private void Start()
	{
        StartCoroutine(WaitThenStart());
	}

	IEnumerator WaitThenStart()
    {
        while(StartDelay>0){
            StartDelay -= Time.deltaTime;
            yield return null;
        }
        Debug.Log("Start");
        Rb.velocity = new Vector2(1.0f, 0.0f) * Speed;
        Debug.Log(Rb.velocity);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        string val = collision.tag;

        if(val == "Pair")
        {
            //if complete live
            //else take damage and maybe die
            TrackPair pair = collision.GetComponent<TrackPair>();
            if(pair.Damaged){
                float angle = Mathf.Deg2Rad * (Random.Range(10.0f, 100.0f) * (Random.Range(0, 2) == 0 ? 1 : -1));
                Rb.velocity = new Vector2(Mathf.Cos(angle) * Rb.velocity.x - Mathf.Sin(angle) * Rb.velocity.y,
                                          Mathf.Sin(angle) * Rb.velocity.x + Mathf.Cos(angle) * Rb.velocity.y);
                Rb.velocity *= 0.75f;
            }

        }
        else if(val == "Link")
        {
            //Get new destinaiton
            collision.GetComponent<TrainLink>().SetNextDirection(this);
        }
	}

    void TakeDamage()
    {
        HP--;
        if(HP <= 0){
            Die();
        }
    }

    void Die(){
        
    }
}
