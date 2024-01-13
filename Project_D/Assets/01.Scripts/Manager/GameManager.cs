using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameSettingsProfile gameSettings;

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
            Managers.Scene.LoadScene(Define.Scene.Main);
        });
    }
}
