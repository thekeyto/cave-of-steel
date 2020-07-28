using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private bool canOpen;
    private bool isOpened;
    private Animator animator;
    private Chip chip;
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpened = false;
        chip.nowChip = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
            
    }
    
}
