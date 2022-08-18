using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
            minute--;
            seconds = seconds + 59;
        }
        timer.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        heroscoretext.text = heroscore.ToString("00000");
        antiheroscoretext.text = antiheroscore.ToString("00000");
        if(heroscore >= 99999)
        {
            heroscore = 99999;
        }
        if(antiheroscore >= 99999)
        {
            antiheroscore = 99999;
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
}
