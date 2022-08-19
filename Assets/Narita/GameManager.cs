using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int minute = 0;
    float seconds = 3f;
    int heroscore = 0;
    int antiheroscore = 0;
    private int lastheroscore = 0;
    private int lastantiheroscore = 0;
    [SerializeField]
    string scenename = null;
    [SerializeField]
    TextMeshProUGUI timer = null;
    [SerializeField]
    TextMeshProUGUI heroscoretext = null;
    [SerializeField]
    TextMeshProUGUI antiheroscoretext = null;
    [SerializeField]
    Text counttext = null;
    [SerializeField]
    Text slimescoretext = null;
    [SerializeField]
    Text bravescoretext = null;
    [SerializeField]
    RawImage slimeWinOrLose = null;
    [SerializeField]
    RawImage braveWinOrLose = null;
    [SerializeField]
    Texture win = null;
    [SerializeField]
    Texture lose = null;
    [SerializeField]
    Texture draw = null;
    [SerializeField]
    GameObject victorycanvas = null;
    [SerializeField]
    GameObject scorecanvas = null;
    [SerializeField]
    GameObject countcanvas = null;
    float count = 3.5f;
    FadeSceneManager fade = null;
    bool judge = false;
    bool start = false;

    public event Action OnGameStart;
    // Start is called before the first frame update
    public void Start()
    {
        //シングルトンなので値を初期化。（前回のプレイデータを保持している可能性があるから）
        fade = FadeSceneManager.Instance;
        //nullチェック
        if (!timer || !heroscoretext || !antiheroscoretext || !slimescoretext 
            || !victorycanvas || !scorecanvas || !countcanvas || !counttext 
            || !slimeWinOrLose || !braveWinOrLose || !win || !lose || !draw)
        {
            start = false;
        }
        heroscore = 0;
        antiheroscore = 0;
        minute = 0;
        seconds = 30;
        count = 3.5f;
        judge = false;
        start = false;
        victorycanvas.SetActive(false);
        scorecanvas.SetActive(false);
        countcanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        heroscoretext.text = heroscore.ToString("00000");
        antiheroscoretext.text = antiheroscore.ToString("00000");
        if (start)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0f)
            {
                if (minute == 0)
                {
                    lastheroscore = heroscore;
                    lastantiheroscore = antiheroscore;
                    judge = true;
                    //start = false;
                    scorecanvas.SetActive(false);
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
        }
        else if (SceneManager.GetActiveScene().name == scenename)
        {
            countcanvas.SetActive(true);
            victorycanvas.SetActive(false);
            scorecanvas.SetActive(false);
            Count();
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
        slimescoretext.text = lastantiheroscore.ToString();
        bravescoretext.text = lastheroscore.ToString();
        if (heroscore > antiheroscore)
        {
            slimeWinOrLose.texture = lose;
            braveWinOrLose.texture = win;
           
        }
        else if (heroscore < antiheroscore)
        {
            slimeWinOrLose.texture = win;
            braveWinOrLose.texture = lose;
        }
        else
        {
            slimeWinOrLose.texture = draw;
            braveWinOrLose.texture = draw;
        }
        victorycanvas.SetActive(true);
    }
    public void Sceneloader(string Scenename)
    {
       fade.SceneChange(Scenename);
     }
    public void Count()
    {
        count -= Time.deltaTime;
        counttext.text = count.ToString("0");
        if (count < 0.5)
        {
            counttext.text = "START";
            if (count < -0.5)
            {
                //OnGameStart();
                start = true;
                counttext.enabled = false;
                scorecanvas.SetActive(true);
                countcanvas.SetActive(false);
            }
        }
    }
}
