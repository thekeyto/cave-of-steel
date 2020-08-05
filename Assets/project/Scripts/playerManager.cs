using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public Transform reBirth;
    public GameObject player;

    GameObject nowplayer;
    void Start()
    {
        nowplayer= Instantiate(player, reBirth) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Destroy(nowplayer);
            nowplayer = Instantiate(player, reBirth) as GameObject;
        }
    }
}
