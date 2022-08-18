using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    /// <summary>�E�҂̃A�j���[�^�[</summary>
    private Animator _anim;
    /// <summary>�E�҂̏d��</summary>
    private Rigidbody _rb;
    /// <summary>�E�҂̕����X�s�[�h</summary>
    [Header("�E�҂̕������x"),SerializeField] float _walkSpeed;
    /// <summary>�E�҂��ǂ����̔���</summary>
    [Header("�E�҂��ǂ���"),Tooltip("�E�҂���������L�[�ł̑���@����Ȃ���������WSAD�ł̑���")]
    [SerializeField] bool _isHero;
    
    public float walkSpeed => _walkSpeed;
    public bool isHero => _isHero;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw(isHero ? "Horizontal1P" : "Horizontal2P");
        float z = Input.GetAxisRaw(isHero ? "Vertical1P" : "Vertical2P");

        _rb.velocity = new Vector3(x * _walkSpeed, 0, z * _walkSpeed);
        Vector3 vel = _rb.velocity;
        if (vel != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }

        _anim.SetFloat("walk",_rb.velocity.magnitude);
        
        if(Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("HeroAttack");
            _anim.SetTrigger("attack");
        }

    }
}
