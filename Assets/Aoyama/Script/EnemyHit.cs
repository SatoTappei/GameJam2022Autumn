using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IHittable
{
    [SerializeField]
    private int _score = 500;
    [SerializeField]
    private string _slimeTag = "Slime";
    [SerializeField]
    private string _heroTag = "Hero";

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
        if (hitObject.tag == _slimeTag)
        {
            Destroy(gameObject);
            _gameManager.AntiHeroScore(_score);
        }
        else if (hitObject.tag == _heroTag)
        {
            Destroy(hitObject);
            _gameManager.HeroScore(_score);
        }
    }
}
