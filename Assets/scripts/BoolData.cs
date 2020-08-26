using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item",menuName="Inventory/new BoolData")]
public class BoolData : ScriptableObject
{
    // Start is called before the first frame update
    public List<bool> itemList = new List<bool>();
    public List<string> taglist=new List<string>();
}
