﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public Sprite NotUseImage;
    public int itemHeld;
    public bool isuse;
    public int property;
    public float rotation;
    [TextArea]
    public string itemInfo;

    public bool equip;
}
