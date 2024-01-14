using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataCreater : MonoBehaviour
{
    public SelectEventDatas datas;
    public string fileName;


    [ContextMenu("CreateData")]
    public void CreateData()
    {
        string json = JsonUtility.ToJson(datas);
        File.WriteAllText(Application.dataPath + $"/05.Datas/{fileName}.json", json);
    }
}
