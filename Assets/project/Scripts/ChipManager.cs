using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoBehaviour
{
    public Inventory playerbag;
    PlayerMove player;
    private void Start()
    {
        player = GetComponent<PlayerMove>();
    }
    void Update()
    {
        for(int i=0;i<5;i++)
            GetComponent<PlayerMove>().chip[i] = false;
        if (player.limitted == true)
        {
            for (int i = 0; i < 3; i++)
                if (playerbag.itemlist[i] != null)
                    player.chip[playerbag.itemlist[i].property] = true;
        }
        else
        {
            for (int i = 0; i < playerbag.itemlist.Count; i++)
                if (playerbag.itemlist[i] != null)
                    player.chip[playerbag.itemlist[i].property] = true;
        }
    }
}
