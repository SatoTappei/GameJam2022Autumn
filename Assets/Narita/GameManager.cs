using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int heroscore = 0;
    int antiheroscore = 0;
    [SerializeField]
    int minute = 2;
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
    bool judge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0f)
        {
            if (minute == 0)
            {
                judge = true;
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
        if (judge)
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
    }
    public void Sceneloader()
    {
        if(judge)
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            SceneManager.LoadScene("ステージsceneの名前");
        }
    }
}
