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
    Text SwinorLose = null;
    [SerializeField]
    Text BwinorLose = null;
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
        //�V���O���g���Ȃ̂Œl���������B�i�O��̃v���C�f�[�^��ێ����Ă���\�������邩��j
        fade = FadeSceneManager.Instance;
        //null�`�F�b�N
        if (!timer || !heroscoretext || !antiheroscoretext || !slimescoretext || !victorycanvas || !scorecanvas || !countcanvas || !counttext)
        {
            start = false;
        }
        heroscore = 0;
        antiheroscore = 0;
        minute = 0;
        seconds = 2;
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
        else if (SceneManager.GetActiveScene().name == "Narita")//�Q�[����scene���ɕύX����
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
            BwinorLose.text = "WIN";
            SwinorLose.text = "LOSE";
        }
        else if (heroscore < antiheroscore)
        {
            BwinorLose.text = "LOSE";
            SwinorLose.text = "WIN";
        }
        else
        {
            BwinorLose.text = "DRAW";
            SwinorLose.text = "DRAW";
        }
        victorycanvas.SetActive(true);
    }
    public void Sceneloader(string name)
    {
       fade.SceneChange(name);
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
