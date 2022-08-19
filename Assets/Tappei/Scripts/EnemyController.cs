using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �G�̈ړ��𐧌䂷��
/// �v���C���[����苗���܂ŋ߂Â�����v���C���[�̂ق��Ɋ���Ă���
/// �v���C���[�Ɨ���Ă����炤�낤�낳����
/// </summary>
public class EnemyController : MonoBehaviour
{
    NavMeshAgent _agent;
    /// <summary>�ړ����x</summary>
    [Header("�ړ����x"), SerializeField] float _speed;
    /// <summary>�G���v���C���[�F�m���鋗��</summary>
    [Header("�G���v���C���[��F�m���鋗��"), SerializeField] float _distance;
    /// <summary>�X���C���̃^�O</summary>
    [Header("�X���C���̃^�O"), SerializeField] string _slimeTag;
    /// <summary>�E�҂̃^�O</summary>
    [Header("�E�҂̃^�O"), SerializeField] string _heroTag;
    /// <summary>�v���C���[�����������ۂɕʂ̒n�_�ւ��낤�낷��܂ł̎���</summary>
    [Header("���낤�낷��ۂ̎~�܂��Ă��鎞��"), SerializeField] float _randomWait;
    /// <summary>�^�C�g����ʂŎg�p������̂�</summary>
    [Header("�^�C�g����ʂŎg�p���邩���̂�"), SerializeField] bool _isTitle;
    /// <summary>�X���C���Ƃ̋������v�Z����̂ɕK�v��Transform</summary>
    Transform _slimeTrans;
    /// <summary>�E�҂Ƃ̋������v�Z����̂ɕK�v��Transform</summary>
    Transform _heroTrans;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
        _slimeTrans = GameObject.FindGameObjectWithTag(_slimeTag).transform;
        _heroTrans = GameObject.FindGameObjectWithTag(_heroTag).transform;
    }

    void Start()
    {
        // �X�|�[�����Ƀ����_���Ȓn�_�ֈړ�������
        SetMovePointRandom();
    }

    void Update()
    {
        if(!_isTitle)
        {
            float slimeDist = (transform.position - _slimeTrans.position).magnitude;
            float heroDist = (transform.position - _heroTrans.position).magnitude;

            // �X���C���A�������͗E�҂Ƃ̋������w�肳�ꂽ�����ȉ���������ǐՂ���
            if (slimeDist < _distance || heroDist < _distance)
            {
                _agent.destination = slimeDist < heroDist ? _slimeTrans.position : _heroTrans.position;
            }
            else
            {
                MoveRandom();
            }
        }
        else
        {
            MoveRandom();
        }
        
    }

    /// <summary>�����_���ȉӏ��Ɉړ�������</summary>
    void MoveRandom()
    {
        // �ڕW�n�_�̖ڑO�܂ŗ�����
        if (!_agent.pathPending && _agent.remainingDistance < 0.1f && !_agent.isStopped)
        {
            // ���̒n�_�Ŏ~�߂āA�w�肵���b��Ɏ��̒n�_�ֈړ�������
            _agent.isStopped = true;
            Invoke("SetMovePointRandom", _randomWait);
        }
    }

    /// <summary>�����_���Ȉʒu�Ɉړ�������</summary>
    void SetMovePointRandom()
    {
        _agent.isStopped = false;

        float rx = Random.Range(-5.0f, 5.0f);
        float rz = Random.Range(-5.0f, 5.0f);

        _agent.destination = new Vector3(transform.position.x + rx, transform.position.y, transform.position.z + rz);
    }
}