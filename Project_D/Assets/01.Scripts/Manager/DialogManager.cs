using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Action callback;
    public DialogData currentData;

    public void Call(int _index, Action _callback = null)
    {
        currentData = Managers.Data.GetDialogData(_index);
        Managers.UI.ShowDialogUI(currentData);
        callback = _callback;
    }

    public void CheckEvent(Action<bool> _callback)
    {
        if (currentData.nextIndex == -2)
        {
            Managers.Event.DialogEvent(currentData.index);
            _callback.Invoke(true);
        }

        else
            _callback.Invoke(false);
    }

    public void OnClick_NextButton()
    {
        if(currentData.nextIndex == -1)
        {
            EndDialog();
        }

        else
        {
            Call(currentData.nextIndex);
        }
    }

    public void EndDialog()
    {
        Managers.UI.CloseDialogUI();
        if(callback != null)
        {
            callback.Invoke();
            callback = null;
        }
    }
}

[System.Serializable]
public class DialogData 
{
    public int index;
    public int nextIndex;
    public string name;
    public string sentence;
    public string uiType;
    public string buttonString;
}