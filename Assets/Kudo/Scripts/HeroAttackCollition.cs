using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/////////////////////////////////////���̃R���C�_�[�̕\���E��\������//////////////////////////////////////////////

public class HeroAttackCollition : MonoBehaviour
{
    private BoxCollider _attackCollider;
    void Start()
    {
        _attackCollider = GameObject.Find("Sword").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack()
    {
        _attackCollider.enabled = true;
    }
    public void OffAttack()
    {
        _attackCollider.enabled = false;
    }
}
