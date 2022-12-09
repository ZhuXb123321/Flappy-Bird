using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GAME_STATUS
{
    Ready,
    Start,
    Over
}
public class GameManager : UnitySinglegon<GameManager>
{
    public  GAME_STATUS status;
    public Action action;

    // Start is called before the first frame update
    private void Awake()
    {
        status = GAME_STATUS.Ready;
        UIManager.Instance.UpdateUI(status);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void GameReady()
    {
        status = GAME_STATUS.Ready;
        UIManager.Instance.UpdateUI(status);
        UIManager.Instance.score = 0;
        UIManager.Instance.ScoreInit();
        action?.Invoke();
    }

    public void GameStart()
    {
        status = GAME_STATUS.Start;
        UIManager.Instance.UpdateUI(status);
        PipelineManager.Instance.StartRun();
    }

    public void GameOver()
    {
        UIManager.Instance.UpdateUI(status);
        UIManager.Instance.ScoreInOver();
        PipelineManager.Instance.Stop();
    }
}
