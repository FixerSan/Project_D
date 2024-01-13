using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    public Dictionary<int, DialogData> dialogDatas = new Dictionary<int, DialogData>();
    public DialogData GetDialogData(int _index)
    {
        if(dialogDatas.TryGetValue(_index, out DialogData _data))   return _data;
        return null;
    }

    public void LoadPreData(Action _callback)
    {
        LoadDialogDatas();
        _callback?.Invoke();
    }

    public void LoadDialogDatas()
    {
        TextAsset text = Managers.Resource.Load<TextAsset>("Data_Dialog");
        DialogDatas datas = JsonUtility.FromJson<DialogDatas>(text.text);
        for (int i = 0; i < datas.datas.Length; i++)
            dialogDatas.Add(datas.datas[i].index, datas.datas[i]);
    }
}

[System.Serializable]
public class DialogDatas
{
    public DialogData[] datas;
}
