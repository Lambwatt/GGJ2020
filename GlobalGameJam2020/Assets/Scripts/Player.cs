using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Rigidbody2D Rb;
    public float Speed;
    public int HP = 3;

    public Text HPText;
    public string HPHeader = "HP: ";

	// Use this for initialization
	void Start () {
        HPText.text = HPHeader + HP;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = new Vector2();

        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector2(-1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector2(0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector2(0, -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector2(1, 0);
        }

        transform.rotation = Quaternion.FromToRotation(Vector2.right, velocity);
        Rb.velocity = velocity * Speed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        string val = collision.tag;
        if(val == "Rock"){
            HP--;
            HPText.text = HPHeader + HP;
            if(HP<=0){
                Die();
            }
        }
	}

    private void Die(){
        SceneManager.LoadScene("EndScreen");
    }
}
