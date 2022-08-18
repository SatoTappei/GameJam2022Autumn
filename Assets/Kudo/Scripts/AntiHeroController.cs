using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiHeroController : MonoBehaviour
{
    /// <summary>スライムのアニメーター</summary>
    private Animator _anim;
    /// <summary>スライムの重力</summary>
    private Rigidbody _rb;
    /// <summary>スライムの歩くスピード</summary>
    [Header("スライムの歩く速度"),SerializeField] float _walkSpeed;
    /// <summary>勇者かどうかの判定</summary>
    [Header("勇者かどうか"), Tooltip("勇者だったら矢印キーでの操作　じゃなっかったらWSADでの操作")]
    [SerializeField] bool _isHero;

    public float walkSpeed => _walkSpeed;
    public bool isHero => _isHero;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw(isHero ? "Horizontal1P" : "Horizontal2P");
        float z = Input.GetAxisRaw(isHero ? "Vertical1P" : "Vertical2P");

        
        _rb.velocity = new Vector3(x * _walkSpeed, 0, z * _walkSpeed);
        Vector3 vel = _rb.velocity;
        if (vel != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }

        _anim.SetFloat("moveSpeed", _rb.velocity.magnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("SlimeAttack");
            _anim.SetTrigger("");
        }
    }
}
