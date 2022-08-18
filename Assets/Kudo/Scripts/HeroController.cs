using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    /// <summary>勇者のアニメーター</summary>
    private Animator _anim;
    /// <summary>勇者の重力</summary>
    private Rigidbody _rb;
    /// <summary>勇者の歩くスピード</summary>
    [Header("勇者の歩く速度"),SerializeField] float _walkSpeed;
    /// <summary>勇者かどうかの判定</summary>
    [Header("勇者かどうか"),Tooltip("勇者だったら矢印キーでの操作　じゃなっかったらWSADでの操作")]
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
