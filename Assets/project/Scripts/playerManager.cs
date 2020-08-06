using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public Transform reBirth;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = reBirth.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Rebirth");
            player.transform.position = reBirth.position;
        }
    }
}
