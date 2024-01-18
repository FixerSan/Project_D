using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UserData userData;
    public GameSettingsProfile gameSettings;
    public DungeonSystem dungeon = new DungeonSystem();

    private void Awake()
    {
        GameStart();
    }

    //���� ���� �Ǿ��� ��
    public void GameStart()
    {
        Managers.Resource.LoadAllAsync<Object>("Preload", _completeCallback: () =>                  //�����ε� ���ҽ� �ε�
        {
            Managers.Data.LoadPreData(() => 
            {
                //gameSettings = Managers.Resource.Load<GameSettingsProfile>("GameSettingsProfile");      //���� ���� ����
                //if (gameSettings.isDebuging)                                                            //����� ���� ��
                //{
                //    Managers.Scene.LoadScene(gameSettings.startScene);
                //    return;
                //}
                Managers.Scene.LoadScene(Define.Scene.Login);
            });

        });
    }

    public void Login()
    {
        Server.Instance.Login(() =>
        {
            userData = Managers.Data.GetUserData(0);
            Managers.Scene.LoadScene(Define.Scene.Main);
        });
    }
}

public class DungeonSystem
{
    public DungeonData currentDungeonData;
    public bool isUsing = false;

    public bool CheckCleard(int _index)
    {
        DungeonCleardData _data = Managers.Data.GetDungeonClearedData(Managers.Game.userData.ID);
        if (_index == 0) return _data.isCleardFirstDungeon;
        return false;
    }

    public void SelectDungeon(int _index)
    {
        currentDungeonData = Managers.Data.GetDungeonData(_index);
        UIPopup_Dungeon_Challenge_Select ui = Managers.UI.ShowPopupUI<UIPopup_Dungeon_Challenge_Select>();
        ui.DrawUI();
    }

    public void SelectCleardDungeon(int _index)
    {
        currentDungeonData = Managers.Data.GetDungeonData(_index);
        UIPopup_Dungeon_Challenge_Select ui = Managers.UI.ShowPopupUI<UIPopup_Dungeon_Challenge_Select>();
        ui.DrawUI();
    }

    public void StartDungeon()
    {
        Managers.Scene.LoadScene(Util.ParseEnum<Define.Scene>($"Scene_{currentDungeonData.name}_One"));
        isUsing = true;
    }
}
