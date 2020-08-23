using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item",menuName="Inventory/new dataSave")]
public class dataSave : ScriptableObject
{
    // Start is called before the first frame update
    public List<Vector3> itemList = new List<Vector3>();
    public List<string> taglist=new List<string>();
}
