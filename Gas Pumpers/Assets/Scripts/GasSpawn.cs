using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawn : MonoBehaviour
{

    public GameObject prefab;
    public Transform spawnPoint;

    void Start(){

    }

    void Update(){
        int numChildren = spawnPoint.childCount;
        if (numChildren == 0){ Invoke(nameof(spawn), 0.0f); }

    }


    void spawn(){
        GameObject newObj = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        newObj.transform.SetParent(spawnPoint);
    }

}