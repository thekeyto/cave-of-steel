using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Canvas text;
    private void OnTriggerStay2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        if (collision.gameObject.CompareTag("Player")&&Input.GetKeyDown(KeyCode.R))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()
    {
        if (!playerInventory.itemlist.Contains(thisItem))
        {
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
