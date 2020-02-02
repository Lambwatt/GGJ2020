using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform Player;
    public Transform LastTrain;

    bool ignore;
    //Vector3 startPostion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!ignore)
        {
            if (Player != null)
            {
                transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
            }
        }
	}

    public void ShowDeathByTrain(){
        ignore = true;
        StartCoroutine(GoToTrain());
        //startPostion = Player.position;
    } 

    IEnumerator GoToTrain(){
        float t = 0;
        float totalTime = 4.0f;
        while(t<4.0f){
            t += Time.deltaTime;
            transform.position = (Vector3)Vector2.Lerp(Player.position, LastTrain.position, t / totalTime)+ new Vector3(0,0,-10);
            yield return null;
        }
        Player = LastTrain;
        ignore = false;
    }
}
