using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public int process = 2;
    public int nowChip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void reactive()
    {
        GameObject player=GameObject.FindGameObjectWithTag("player");
        player.GetComponent<PlayerMove>().chip[nowChip] = true;
        
    }
}
