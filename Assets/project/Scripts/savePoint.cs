using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    public Transform ReBirth; 
    SpriteRenderer nowsprite;
    public Sprite saved;
    AudioSource audio;
    private void Start()
    {
        nowsprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&Input.GetKeyDown(KeyCode.I))
        {
            if (!audio.isPlaying) audio.Play();
            nowsprite.sprite = saved;
            ReBirth.position = transform.position;
            collision.GetComponent<PlayerMove>().notlimit();
        }
    }
}
