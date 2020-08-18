
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class save : MonoBehaviour
{
    public GameObject player;
    public bool isSave;
    void Update()
    {
        pressLoad();
    }
    void saveObject()
    {
        Debug.Log(Application.persistentDataPath +"/game_saveData");
        if(!Directory.Exists(Application.persistentDataPath +"/game_saveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath +"/game_saveData");
        }
        BinaryFormatter formatter = new BinaryFormatter();//二进制转化
        FileStream file = File.Create(Application.persistentDataPath +"/game_saveData/save.txt");
        var json = JsonUtility.ToJson(player);
        formatter.Serialize(file,json);
        file.Close();

    }
    void load()
    {
        BinaryFormatter bf =new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath +"/game_saveData/save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath +"/game_saveData/save.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),player);
            file.Close();
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Player")
        {
            
            saveObject();
            isSave=true;
            
        }

    }
    void pressLoad()
    {
        if(Input.GetKey(KeyCode.L))
        {
            load();
        }
    } 
}
