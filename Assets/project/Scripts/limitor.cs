using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("limitor");
            collision.GetComponent<PlayerMove>().limit();
        }    
    }
}
