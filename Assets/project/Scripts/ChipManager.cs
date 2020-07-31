using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoBehaviour
{
    public Inventory playerbag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<5;i++)
            GetComponent<PlayerMove>().chip[i] = false;
        for (int i = 0; i < 3; i++)
            if (playerbag.itemlist[i]!=null)
            GetComponent<PlayerMove>().chip[playerbag.itemlist[i].property] = true;
    }
}
