using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    int minute = 1;
    float seconds = 0f;
    [SerializeField]
    TextMeshPro timer = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60f)
        {
            minute++;
            seconds = seconds-60;
        }
        timer.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
    }
}
