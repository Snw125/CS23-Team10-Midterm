using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackSpawn : MonoBehaviour
{

    public GameObject snackPrefab;
    public Transform spawnPoint;

    void Start(){

    }

    void Update(){
        int numChildren = spawnPoint.childCount;
        if (numChildren == 0){ Invoke(nameof(spawnSnack), 0.0f); }

    }


    void spawnSnack(){
        GameObject newSnack = Instantiate(snackPrefab, spawnPoint.position, Quaternion.identity);
        newSnack.transform.SetParent(spawnPoint);
    }

}