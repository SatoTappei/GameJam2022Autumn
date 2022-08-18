using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerHit : MonoBehaviour, IHittable
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
    /// ���l�ɐڐG�����Ƃ��ɌĂяo���֐�
    /// </summary>
    /// <param name="hitObject">���̊֐����Ăяo���I�u�W�F�N�g</param>
    public void Hit(GameObject hitObject)
    {
        //�������Ă����v���C���[�̔����Tag�s��
        if(hitObject.tag == _player1)
        {
            Debug.Log("player1�ɓ�������");
        }
        else if(hitObject.tag == _player2)
        {
            Debug.Log("player2�ɓ�������");

            Destroy(hitObject);
            _gameManager.AntiHeroScore(_score);
        }
    }
}
