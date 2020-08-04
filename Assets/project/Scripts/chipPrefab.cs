using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New ChipList", menuName = "Inventory/New ChipList")]
public class chipPrefab : ScriptableObject
{
    public List<GameObject> itemlist = new List<GameObject>();
}
