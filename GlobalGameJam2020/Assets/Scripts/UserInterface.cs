using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInterface : MonoBehaviour {

    public UnityEvent OnA;
    public UnityEvent OnW;
    public UnityEvent OnS;
    public UnityEvent OnD;
    public UnityEvent OnSpace;

	//// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.A)){
            OnA.Invoke();
        }

        if (Input.GetKey(KeyCode.W))
        {
            OnW.Invoke();
        }

        if (Input.GetKey(KeyCode.S))
        {
            OnS.Invoke();
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnD.Invoke();
        }

        if(Input.GetKey(KeyCode.Space)){
            OnSpace.Invoke();
        }
	}
}
