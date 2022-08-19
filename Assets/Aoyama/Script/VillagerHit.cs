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
    /// ���l�ɐڐG�����Ƃ��ɌĂяo���֐�
    /// </summary>
    /// <param name="hitObject">���̊֐����Ăяo���I�u�W�F�N�g</param>
    public void Hit(GameObject hitObject)
    {
        //�������Ă����v���C���[�̔����Tag�s��
        if(hitObject.tag == _slimeTag)
        {
            Debug.Log("player1�ɓ�������");
            Destroy(gameObject);
            _gameManager.AntiHeroScore(_score);
        }
    }
}
