using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup_SelectEvent : UIPopup
{
    public SelectEventData data;
    public override bool Init()
    {
        if (!base.Init()) return false;
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        BindEvent(GetButton((int)Buttons.Button_SelectOne).gameObject, OnClick_SelectOne);
        BindEvent(GetButton((int)Buttons.Button_SelectTwo).gameObject, OnClick_SelectTwo);

        return true;
    }

    public void RedrawUI(SelectEventData _data)
    {
        data = _data;
        GetText((int)Texts.Text_Sentence).text = data.sentence;
        GetText((int)Texts.Text_SelectOne).text = data.selectOneText;
        GetText((int)Texts.Text_SelectTwo).text = data.selectTwoText;
    }

    public void OnClick_SelectOne()
    {
        Managers.Event.SelectOneEvent(data.index);
        Managers.UI.CloseSelectEventUI();
    }

    public void OnClick_SelectTwo()
    {
        Managers.Event.SelectTwoEvent(data.index);
        Managers.UI.CloseSelectEventUI();
    }

    private enum Texts
    {
        Text_Sentence, Text_SelectOne, Text_SelectTwo
    }
    private enum Buttons
    {
        Button_SelectOne, Button_SelectTwo
    }
    private enum Image
    {

    }

    private void OnDisable()
    {
        GetText((int)Texts.Text_Sentence).text = string.Empty;
        GetText((int)Texts.Text_SelectOne).text = string.Empty;
        GetText((int)Texts.Text_SelectTwo).text = string.Empty;
    }
}
