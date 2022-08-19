using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScore : MonoBehaviour//今回は勇者
{
    /// <summary>
    /// ヒーローの合計スコア
    /// </summary>
    private int heroscore = 0;
    /// <summary>
    /// 加算スコア
    /// </summary>
    [SerializeField]
    int score = 25;
    public GameObject mamono;
    public int Heroscore { get => heroscore; set => heroscore = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {

    }
 
}
