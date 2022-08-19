using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    [Header("パラメーター")]
    [SerializeField]
    private float _speed = 5;
    [Header("自己参照")]
    [SerializeField]
    Rigidbody _rb;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        StartCoroutine(Cor());
    }

    private void Update()
    {
        Move();
    }

    float _x = 0;
    float _z = 0;
    private void Move()
    {
        Vector3 dir = new Vector3(_x,0,_z);
        _rb.velocity = dir.normalized;

        Vector3 look = new Vector3(_x + transform.position.x, transform.position.y, _z + transform.position.z);
        transform.LookAt(look);
    }

    private float n = 1;
    IEnumerator Cor()
    {
        _x = _speed * Random.Range(-1, 1);
        _z = _speed * Random.Range(-1, 1);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Cor());
    }
}
