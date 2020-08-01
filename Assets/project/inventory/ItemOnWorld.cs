using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Canvas text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        text.gameObject.SetActive(false);
    }
    public void AddNewItem()
    {
        if (!playerInventory.itemlist.Contains(thisItem))
        {
            //playerInventory.itemlist.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for(int i=0;i<playerInventory.itemlist.Count;i++)
            {
                if (playerInventory.itemlist[i]==null)
                {
                    playerInventory.itemlist[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
