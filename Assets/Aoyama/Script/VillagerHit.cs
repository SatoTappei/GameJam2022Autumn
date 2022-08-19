using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerHit : MonoBehaviour, IHittable
{
    [SerializeField]
    private int _score = 250;
    [SerializeField]
    private string _slimeTag = "Slime";
    [SerializeField]
    private string _HeroTag = "Hero";

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    /// <summary>
    /// 村人に接触したときに呼び出す関数
    /// </summary>
    /// <param name="hitObject">この関数を呼び出すオブジェクト</param>
    public void Hit(GameObject hitObject)
    {
        //当たってきたプレイヤーの判定はTag行う
        if(hitObject.tag == _slimeTag)
        {
            Debug.Log("player1に当たった");
            Destroy(gameObject);
            _gameManager.AntiHeroScore(_score);
        }
    }
}
