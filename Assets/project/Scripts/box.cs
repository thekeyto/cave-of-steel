using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Inventory playerBag;
    bool chipHeld = false;
    public chipPrefab ChipPrefab;
    Item chip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boxwitharm"))
        {
            gameObject.tag = "boxwitharm1";
        }
    }
    public void Chip()
    {
        if (chipHeld==false&&playerBag.itemlist[3]!=null)
        {
            chipHeld = true;
            chip = playerBag.itemlist[3];
            playerBag.itemlist[3] = null;
            InventoryManager.RefreshItem();
        }
        else
        {
            Vector2 temp = transform.position;
            temp.y += 1.5f;
            Instantiate(ChipPrefab.itemlist[chip.property],transform.position,transform.rotation);
            chipHeld = false;
        }
    }
}
