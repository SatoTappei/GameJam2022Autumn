using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSlimeMove : MonoBehaviour, IHittable
{
    [SerializeField]
    private float _speed = 3;
    [Header("���ȎQ��")]
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

        Vector3 vel = _rb.velocity;
        if (vel != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IHittable hittable))
        {
            hittable.Hit(gameObject);
        }
    }

    public void Hit(GameObject hitObject)
    {
        if (hitObject.tag == "Hero")
        {
            Destroy(gameObject);
        }
    }
}
