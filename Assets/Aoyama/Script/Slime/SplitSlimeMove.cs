using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSlimeMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    [Header("é©å»éQè∆")]
    [SerializeField]
    Rigidbody _rb;

    private EnemyManager _enemyManager;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _enemyManager = EnemyManager.Instance;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = _enemyManager.SearchNearEnemyDirection(transform) * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IHittable>(out IHittable hittable))
        {
            hittable.Hit(gameObject);
        }
    }
}
