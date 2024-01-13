using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public DialogDatas datas;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            string json = JsonUtility.ToJson(datas, true);
            File.WriteAllText(Application.dataPath + "/05.Datas/Data_Dialog.json", json);
        }
    }
}
