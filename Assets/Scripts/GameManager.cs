using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : UnitySinglegon<GameManager>
{
    public  GAME_STATUS status;
    public Action action;
    public LevelManager levelManager;
    public int currentLevelId = 1;

    
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
        UIManager.Instance.InitRank();
        PipelineManager.Instance.StartRun();
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        //¹Ø¿¨Éú³É
        LevelManager.Instance.LoadLevel(this.currentLevelId);
        LevelManager.Instance.level.gameEnd = GameEnd;
        UIManager.Instance.levelName.text = LevelManager.Instance.level.Name;
    }

    private void GameEnd(LEVEL_STATUS lEVEL_STATUS)
    {
        if (lEVEL_STATUS==LEVEL_STATUS.Success)
        {
            this.currentLevelId += 1;
            GenerateLevel();
        }
        else
        {
            this.status = GAME_STATUS.Over;
        }
    }

    public void GameOver()
    {
        UIManager.Instance.UpdateUI(status);
        UIManager.Instance.SaveData();
        PipelineManager.Instance.Stop();
    }
}
