using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiHeroScore : MonoBehaviour//今回はスライム
{
    /// <summary>
    /// アンチヒーローの合計スコア
    /// </summary>
    private int antiheroscore = 0;
    /// <summary>
    /// 加算スコア
    /// </summary>
    [SerializeField]
    int score = 50;
    [SerializeField]
    int minusheroscore = 20;
    public int Antiheroscore { get => antiheroscore; set => antiheroscore = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("魔物のタグ"))
        {
            antiheroscore += score;
        }
        if (other.gameObject.CompareTag("村人のタグ"))
        {
            //勇者のスコアを引く
        }
    }
}
