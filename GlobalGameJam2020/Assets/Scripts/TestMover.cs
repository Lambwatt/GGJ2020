using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMover : MonoBehaviour {

    public float speed;

    public void MoveUp(){
        transform.position += new Vector3(0,speed,0);
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0, -speed, 0);
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-speed, 0, 0);
    }

    public void MoveRight()
    {
        transform.position += new Vector3(speed, 0, 0);
    }

    public void Die(){
        SceneManager.LoadScene("EndScreen");
    }
}
