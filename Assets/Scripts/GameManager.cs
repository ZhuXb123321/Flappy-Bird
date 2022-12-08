using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME_STATUS
{
    Ready,
    InGame,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public GameObject gameReady;
    public GameObject gameStart;
    public GameObject gameOver;

    public PipelineManager pipelineManager;

    public  GAME_STATUS status;

    // Start is called before the first frame update
    private void Awake()
    {
        this.gameReady.SetActive(true);
        status = GAME_STATUS.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        status = GAME_STATUS.InGame;
        UpDateUI();
        pipelineManager.StartRun();
    }
    public void UpDateUI()
    {
        this.gameReady.SetActive(status == GAME_STATUS.Ready);
        this.gameStart.SetActive(status == GAME_STATUS.InGame);
        this.gameOver.SetActive(status == GAME_STATUS.GameOver);
    }
}
