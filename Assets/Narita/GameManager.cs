using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int heroscore = 0;
    int antiheroscore = 0;
    [SerializeField]
    int minute = 1;
    float seconds = 0f;
    [SerializeField]
    TextMeshProUGUI timer = null;
    [SerializeField]
    TextMeshProUGUI heroscoretext = null;
    [SerializeField]
    TextMeshProUGUI antiheroscoretext = null;
    [SerializeField]
    Text victorytext = null;
    [SerializeField]
    GameObject victorycanvas = null;
    [SerializeField]
    GameObject scorecanvas = null;
    [SerializeField]
    Text counttext = null;
    FadeSceneManager fade = null;
    bool judge = false;
    bool start = true;
    public event Action OnGameStart;
    // Start is called before the first frame update
    void Start()
    {
        //シングルトンなので値を初期化。（前回のプレイデータを保持している可能性があるから）
        heroscore = 0;
        antiheroscore = 0;
        minute = 1;
        seconds = 0;
        judge = false;
        fade = FadeSceneManager.Instance;
        //nullチェック
        if (!timer || !heroscoretext || !antiheroscoretext || !victorytext || !victorycanvas || !scorecanvas || !counttext)
        {
            start = false;
        }
        else
        {
            start = true;
        }
    　　//タイトルだったら
        if (SceneManager.GetActiveScene().name == "Title")
        {
            victorycanvas.SetActive(false);
            scorecanvas.SetActive(false);
        }
        else
        {
            Count();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0f)
            {
                if (minute == 0)
                {
                    judge = true;
                    start = false;
                    Judge();
                }
                else
                {
                    minute--;
                    seconds = seconds + 60;
                }
            }
            if (heroscore >= 99999)
            {
                heroscore = 99999;
            }
            if (antiheroscore >= 99999)
            {
                antiheroscore = 99999;
            }
            timer.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
            heroscoretext.text = heroscore.ToString("00000");
            antiheroscoretext.text = antiheroscore.ToString("00000");
        }
    }
    public void HeroScore(int score)
    {
        heroscore += score;
    }
    public void AntiHeroScore(int score)
    {
        antiheroscore += score;
    }
    public void Judge()
    {
            if (heroscore > antiheroscore)
            {
                victorytext.text = "勇者の勝利";
            }
            else if (heroscore < antiheroscore)
            {
                victorytext.text = "スライムの勝利";
            }
            else
            {
                victorytext.text = "引き分け";
            }
            victorycanvas.SetActive(true);
            scorecanvas.SetActive(false);
    }
    public void Sceneloader()
    {
        if (judge)
        {
            fade.SceneChange("Title");
        }
        else
        {
            fade.SceneChange("Narita");
        }
    }
    public void Count()
    {
        for(int i = 3; 0 <= i; i--)
        {
            counttext.text = i.ToString();
            if(i == 0)
            {
                counttext.text = "START";
                OnGameStart();
            }
        }
    }
}
