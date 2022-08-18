using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("�ړ����x"), SerializeField] float _speed;
    NavMeshAgent _agent;
    /// <summary>�^�[�Q�b�g��Transform</summary>
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

    /// <summary>�^�[�Q�b�g���Z�b�g���ĒǐՊJ�n</summary>
    public void StartChase(Transform target) => _target = target;
}
