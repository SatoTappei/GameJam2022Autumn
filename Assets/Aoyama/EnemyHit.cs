using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IHittable
{
    [SerializeField]
    private int _score = 500;
    [SerializeField]
    private string _player1 = "Player1";
    [SerializeField]
    private string _player2 = "Player2";

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    /// <summary>
    /// モンスターに接触したときに呼び出す関数
    /// </summary>
    /// <param name="hitObject">この関数を呼び出すオブジェクト</param>
    public void Hit(GameObject hitObject)
    {
        //当たってきたプレイヤーの判定はTag行う
        if (hitObject.tag == _player1)
        {
            Debug.Log("player1に当たった");

            Destroy(gameObject);
            _gameManager.HeroScore(_score);
        }
        else if (hitObject.tag == _player2)
        {
            Debug.Log("player2に当たった");

            Destroy(hitObject);
            _gameManager.AntiHeroScore(_score);
        }
    }
}
