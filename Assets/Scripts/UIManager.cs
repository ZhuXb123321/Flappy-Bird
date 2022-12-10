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
    public Text scoreOver;
    public Text bestOver;
    public Slider healthSlider;
    // Start is called before the first frame update

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
        bestOver.text = scorePres.ToString();
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
}
