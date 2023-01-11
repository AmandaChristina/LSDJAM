using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    GameObject spawnPlayer;
    [SerializeField]
    Canvas canvas;


    
    void Awake()
    {
        spawnPlayer = GameObject.Find("SpawnPlayer");
        Instantiate(canvas);
        Instantiate(player, spawnPlayer.transform.position, spawnPlayer.transform.rotation);
    }

    void Update()
    {
        
    }

}
