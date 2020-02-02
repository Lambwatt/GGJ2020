using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    List<Transform> objs;

    public Transform[] spawnable;
    public int numObjects = 20;
    public float killRadius = 10;
    public float spawnRadius = 5;
    public int MaxSpawnsPerUpdate = 2;

    bool active = false;

	private void Start()
	{
        objs = new List<Transform>();
        //Spawn(numObjects);
	}

	private void Update()
	{
        if (active)
        {
            List<Transform> killList = GetKillList();
            Kill(killList);

            Spawn(Mathf.Min(numObjects - objs.Count, MaxSpawnsPerUpdate), spawnRadius);
        }
	}

    public void ActivateSpawner(){
        active = true;

    }

    public void StopTracking(Transform obj){
        objs.Remove(obj);
    }

    List<Transform> GetKillList()
    {
        List<Transform> killList = new List<Transform>();
        for (int i = 0; i < objs.Count; i++){
            if(Vector3.Distance(transform.position, objs[i].position) > killRadius){
                killList.Add(objs[i]);
            }
        }
        return killList;
    }

    void Kill(List<Transform> killList){
        for (int i = killList.Count-1; i>=0; i--){
            objs.Remove(killList[i]);
            Destroy(killList[i].gameObject);
            killList.RemoveAt(killList.Count - 1);
        }
    }

    void Spawn(int numSpawns, float minRadius = 0)
    {

        for (int i = 0; i < numSpawns; i++)
        {
            objs.Add(Instantiate<Transform>(
                spawnable[Random.Range(0, spawnable.Length)], 
                transform.position + Tools.RandomDirection() * Random.Range(minRadius, killRadius),
                Quaternion.identity));
        }
    }

}

