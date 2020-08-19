using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item",menuName="Inventory/new Inventry")]
public class Inventory : ScriptableObject
{
    // Start is called before the first frame update
    public List<Item> itemList = new List<Item>();
}
