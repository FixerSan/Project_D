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

    //게임 시작 되었을 때
    public void GameStart()
    {
        Managers.Resource.LoadAllAsync<Object>("Preload", _completeCallback: () =>                  //프리로드 리소스 로드
        {
            Managers.Data.LoadPreData(() => 
            {
                gameSettings = Managers.Resource.Load<GameSettingsProfile>("GameSettingsProfile");      //게임 세팅 설정
                if (gameSettings.isDebuging)                                                            //디버깅 중일 때
                {
                    Managers.Scene.LoadScene(gameSettings.startScene);
                    return;
                }            
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

    public bool CheckCleard(int _index)
    {
        DungeonCleardData _data = Managers.Data.GetDungeonClearedData(Managers.Game.userData.ID);
        if (_index == 0) return _data.isCleardFirstDungeon;
        return false;
    }

    public void SelectDungeon(int _index)
    {

    }

    public void SelectCleardDungeon(int _index)
    {

    }

    public void StartDungeon()
    {

    }
}
