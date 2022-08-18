using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerHit : MonoBehaviour
{
    [SerializeField]
    private string _player1 = "Player1";
    [SerializeField]
    private string _player2 = "Player2";

    /// <summary>
    /// 村人に接触したときに呼び出す関数
    /// </summary>
    /// <param name="hitObject">当たってきたオブジェクト自身</param>
    public void Hit(GameObject hitObject)
    {
        //当たってきたプレイヤーの判定はTag行う
        if(hitObject.tag == _player1)
        {
            Debug.Log("player1に当たった");
        }
        else if(hitObject.tag == _player2)
        {
            Debug.Log("player2に当たった");
        }
    }
}
