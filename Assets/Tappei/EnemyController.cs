using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("移動速度"), SerializeField] float _speed;
    NavMeshAgent _agent;
    /// <summary>ターゲットのTransform</summary>
    Transform _target;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (_target != null)
        {
            _agent.SetDestination(_target.position);
        }
    }

    /// <summary>ターゲットをセットして追跡開始</summary>
    public void StartChase(Transform target) => _target = target;
}
