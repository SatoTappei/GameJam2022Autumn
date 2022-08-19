using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    [SerializeField]
    GameObject[] story = new GameObject[4];
    [SerializeField]
    GameObject canvas = null;
    int number = 1;
    bool play = false;
    bool back = false;
    public bool Play { get => play; set => play = value; }
    public bool Back { get => back; set => back = value; }

    private void Update()
    {
        if (play)
        {
            StoryPlay(number);
        }
    }
    // Start is called before the first frame update
    public void StoryPlay(int num)
    {
        for(int i = 0; i < story.Length; i++)
        {
            if (i == num)
            {
                story[i].SetActive(true);
            }
            else
            {
                story[i].SetActive(false);
            }
        }
        if (!back)
        {
            if (num < story.Length - 1)
            {
                number++;
            }
        }
        else
        {
            if (num > 0)
            {
                number--;
            }
        }
        Debug.Log(number);
        Debug.Log(back);
        back = false;
        play = false;
    }
}
