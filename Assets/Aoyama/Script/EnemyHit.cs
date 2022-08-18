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
    /// �����X�^�[�ɐڐG�����Ƃ��ɌĂяo���֐�
    /// </summary>
    /// <param name="hitObject">���̊֐����Ăяo���I�u�W�F�N�g</param>
    public void Hit(GameObject hitObject)
    {
        //�������Ă����v���C���[�̔����Tag�s��
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
