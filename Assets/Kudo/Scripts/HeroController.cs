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
    [SerializeField] bool isHero;
    
    
    public float walkSpeed => _walkSpeed;
    public bool IsHero => isHero;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GameObject.Find("Attack").GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter))　//剣攻撃のアニメーション
        {
            Debug.Log("HeroAttack");
            _anim.SetTrigger("attack");
        }
    }


    void FixedUpdate()
    {
        float x = Input.GetAxisRaw(IsHero ? "Horizontal1P" : "Horizontal2P");
        float z = Input.GetAxisRaw(IsHero ? "Vertical1P" : "Vertical2P");

        _rb.velocity = new Vector3(x * _walkSpeed, 0, z * _walkSpeed);
        Vector3 vel = _rb.velocity;
        if (vel != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }

    }
}
