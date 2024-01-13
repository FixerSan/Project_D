using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameSettingsProfile gameSettings;

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
                gameSettings = Managers.Resource.Load<GameSettingsProfile>("GameSettingsProfile");      //���� ���� ����
                if (gameSettings.isDebuging)                                                            //����� ���� ��
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
