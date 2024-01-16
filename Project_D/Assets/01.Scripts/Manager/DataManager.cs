using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    public Dictionary<int, DialogData> dialogDatas = new Dictionary<int, DialogData>();
    public Dictionary<int, SelectEventData> selectEventDatas = new Dictionary<int, SelectEventData>();
    public Dictionary<int, DungeonData> dungeonDatas = new Dictionary<int, DungeonData>();
    public Dictionary<int, DungeonCleardData> dungeonClearedDatas = new Dictionary<int, DungeonCleardData>();
    public Dictionary<int, UserData> userDatas = new Dictionary<int, UserData>();
    public DialogData GetDialogData(int _index)
    {
        if(dialogDatas.TryGetValue(_index, out DialogData _data))   return _data;
        return null;
    }

    public SelectEventData GetSelectEventData(int _index)
    {
        if (selectEventDatas.TryGetValue(_index, out SelectEventData _data)) return _data;
        return null;
    }
    public DungeonData GetDungeonData(int _index)
    {
        if (dungeonDatas.TryGetValue(_index, out DungeonData _data)) return _data;
        return null;
    }
    public DungeonCleardData GetDungeonClearedData(int _index)
    {
        if (dungeonClearedDatas.TryGetValue(_index, out DungeonCleardData _data)) return _data;
        return null;
    }
    public UserData GetUserData(int _index)
    {
        if (userDatas.TryGetValue(_index, out UserData _data)) return _data;
        return null;
    }

    public void LoadPreData(Action _callback)
    {
        LoadDialogDatas();
        LoadSelectEventData();
        LoadDungeonData();
        LoadDungeonClearedData();
        LoadUserData();
        _callback?.Invoke();
    }

    public void LoadDialogDatas()
    {
        TextAsset text = Managers.Resource.Load<TextAsset>("Data_Dialog");
        DialogDatas datas = JsonUtility.FromJson<DialogDatas>(text.text);
        for (int i = 0; i < datas.datas.Length; i++)
            dialogDatas.Add(datas.datas[i].index, datas.datas[i]);
    }

    public void LoadSelectEventData()
    {
        TextAsset text = Managers.Resource.Load<TextAsset>("Data_SelectEvent");
        SelectEventDatas datas = JsonUtility.FromJson<SelectEventDatas>(text.text);
        for (int i = 0; i < datas.datas.Length; i++)
            selectEventDatas.Add(datas.datas[i].index, datas.datas[i]);
    }

    public void LoadDungeonData()
    {
        TextAsset text = Managers.Resource.Load<TextAsset>("Data_Dungeon");
        DungeonDatas datas = JsonUtility.FromJson<DungeonDatas>(text.text);
        for (int i = 0; i < datas.datas.Length; i++)
            dungeonDatas.Add(datas.datas[i].index, datas.datas[i]);
    }

    public void LoadDungeonClearedData()
    {
        TextAsset text = Managers.Resource.Load<TextAsset>("Data_DungeonCleared");
        DungeonCleardDatas datas = JsonUtility.FromJson<DungeonCleardDatas>(text.text);
        for (int i = 0; i < datas.datas.Length; i++)
            dungeonClearedDatas.Add(datas.datas[i].UserID, datas.datas[i]);
    }

    public void LoadUserData()
    {
        TextAsset text = Managers.Resource.Load<TextAsset>("Data_User");
        UserDatas datas = JsonUtility.FromJson<UserDatas>(text.text);
        for (int i = 0; i < datas.datas.Length; i++)
            userDatas.Add(datas.datas[i].ID, datas.datas[i]);
    }
}

[System.Serializable]
public class DialogDatas
{
    public DialogData[] datas;
}

[System.Serializable]
public class SelectEventDatas
{
    public SelectEventData[] datas;
}

[System.Serializable]
public class SelectEventData
{
    public int index;
    public string sentence;
    public string selectOneText;
    public string selectTwoText;
}

[System.Serializable]
public class DungeonDatas
{
    public DungeonData[] datas;
}

[System.Serializable]
public class DungeonData
{
    public int index;
    public string name;
    public string description;
    public Define.PlayerTier tier;
}

[System.Serializable]
public class DungeonCleardDatas
{
    public DungeonCleardData[] datas;
}

[System.Serializable]
public class DungeonCleardData
{
    public int UserID;
    public bool isCleardFirstDungeon;
}


[System.Serializable]
public class UserDatas
{
    public UserData[] datas;
}

[System.Serializable]
public class UserData
{
    public int ID;
    public Define.PlayerTier tier;
}