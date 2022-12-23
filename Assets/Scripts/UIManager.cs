using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : UnitySinglegon<UIManager>
{
    public GameObject gameReady;
    public GameObject gameStart;
    public GameObject gameOver;
    public int score = 0;
    public Text scoreStart;
    public Text BestText1;
    public Text BestText2;
    public Text BestText3;
    public Text scoreOver;
    public Text levelName;
    public Text healthNum;
    public Slider healthSlider;
    private string NO1 = "No1";
    private string NO2 = "No2";
    private string NO3 = "No3";
    public List<int> rangking;

    public void InitRank()
    {
        rangking = new List<int>();
        rangking.Add(PlayerPrefs.GetInt(NO1));
        rangking.Add(PlayerPrefs.GetInt(NO2));
        rangking.Add(PlayerPrefs.GetInt(NO3));
        //rangking.Sort();
    }

    private void LoadData()
    {
        for (int i = 0; i < rangking.Count; i++)
        {
            rangking[i] = PlayerPrefs.GetInt("No" + (i + 1));
        }
        scoreOver.text = score.ToString();
        BestText1.text = rangking[0].ToString();
        BestText2.text = rangking[1].ToString();
        BestText3.text = rangking[2].ToString();
    }

    public void SaveData()
    {
        LoadData();
        for (int i = 0; i < rangking.Count; i++)
        {
            int No2, No3;
            if (score > rangking[i])
            {
                if (i == 0)
                {
                    No2 = rangking[i];
                    No3 = rangking[i + 1];
                    rangking[i] = score;
                    rangking[i + 1] = No2;
                    rangking[i + 2] = No3;
                    PlayerPrefs.SetInt(NO1, score);
                    PlayerPrefs.SetInt(NO2, rangking[i + 1]);
                    PlayerPrefs.SetInt(NO3, rangking[i + 2]);
                    LoadData();
                    return;
                }
                if (i == 1)
                {
                    No3 = rangking[i];
                    rangking[i] = score;
                    rangking[i + 1] = No3;
                    PlayerPrefs.SetInt(NO2, score);
                    PlayerPrefs.SetInt(NO3, rangking[i + 1]);
                    LoadData();
                    return;
                }
                if (i == 2)
                {
                    rangking[i] = score;
                    PlayerPrefs.SetInt(NO3, score);
                    LoadData();
                }
            }
        }
    }

    public void UpdateUI(GAME_STATUS state)
    {
        this.gameReady.SetActive(state == GAME_STATUS.Ready);
        this.gameStart.SetActive(state == GAME_STATUS.Start);
        this.gameOver.SetActive(state == GAME_STATUS.Over);
    }

    public void ScoreInGame(int intScore)
    {
        score += intScore;
        scoreStart.text = score.ToString();
    }

    public void ScoreInOver()
    {
        int scorePres = PlayerPrefs.GetInt("score");
        if (score>scorePres)
        {
            PlayerPrefs.SetInt("score", score);
        }
        scorePres = PlayerPrefs.GetInt("score");
        scoreOver.text = score.ToString();
        BestText2.text = scorePres.ToString();
    }

    public void ScoreInit()
    {
        scoreStart.text = score.ToString();
    }

    public void InitHealth(int maxHp, int currentHp)
    {
        healthSlider.maxValue = maxHp;
        currentHp = maxHp;
        healthSlider.value = currentHp;
    }

    public void HealthUpdate(int currentHp)
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHp, 1f);
    }

    public void HealthNum(int life)
    {
        healthNum.text = "Health " + life;
    }
}
