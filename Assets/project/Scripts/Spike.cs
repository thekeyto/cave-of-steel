﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage=30;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&collision.GetType().ToString()== "UnityEngine.PolygonCollider2D")
            collision.gameObject.GetComponent<PlayerMove>().takeDamage(damage);
    }
}