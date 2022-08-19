using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ���l�̈ړ��𐧌䂷��
/// �����_���Ɉړ����āA�v���C���[���߂Â��Ă����瑬�x���グ�Ă��낤�낷��
/// </summary>
public class PersonControllerMoveRandom : MonoBehaviour
{
    NavMeshAgent _agent;
    /// <summary>�X���C���̃^�O</summary>
    [Header("�X���C���̃^�O"), SerializeField] string _slimeTag;
    /// <summary>�E�҂̃^�O</summary>
    [Header("�E�҂̃^�O"), SerializeField] string _heroTag;
    /// <summary>�ړ����x</summary>
    [Header("�ړ����x"), SerializeField] float _speed;
    /// <summary>��������ۂ̃X�s�[�h�̈ړ����x</summary>
    [Header("��������ۂ̈ړ����x"), SerializeField] float _escapeSpeed;
    /// <summary>�ړ���̑ҋ@����</summary>
    [Header("�ړ���̑ҋ@����"), SerializeField] float _standby;
    /// <summary>��������ۂ̈ړ���̑ҋ@����</summary>
    [Header("��������ۂ̈ړ���̑ҋ@����"), SerializeField] float _escapeStandby;
    /// <summary>�G���v���C���[�F�m���鋗��</summary>
    [Header("�G���v���C���[��F�m���鋗��"), SerializeField] float _distance;
    /// <summary>���̈ړ�����</summary>
    [Header("���̈ړ�����"), SerializeField] float _moveDist;
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
        MoveRandomPoint();
    }

    void Update()
    {
        // �X���C���Ǝ��g�A�E�҂Ǝ��g�̋����𑪂�
        float slimeDist = (transform.position - _slimeTrans.position).magnitude;
        float heroDist = (transform.position - _heroTrans.position).magnitude;
        // �X���C���������͗E�҂Ǝ��g���������ȉ��Ȃ瓦�����Ԃɂ���
        bool isEscape = slimeDist < _distance || heroDist < _distance;
        // �������Ԃ瑬�x���グ�A�ړ���̑ҋ@���Ԃ�Z������
        _agent.speed = isEscape ? _escapeSpeed : _speed;
        _standby = isEscape ? _escapeStandby : _standby;

        // �ڕW�n�_�̖ڑO�܂ŗ�����
        if (!_agent.pathPending && _agent.remainingDistance < 0.1f && !_agent.isStopped)
        {
            // ���̒n�_�Ŏ~�߂āA�w�肵���b��Ɏ��̒n�_�ֈړ�������
            _agent.isStopped = true;
            Invoke("MoveRandomPoint", _standby);
        }
    }

    /// <summary>�����_���Ȉʒu�Ɉړ�������</summary>
    void MoveRandomPoint()
    {
        _agent.isStopped = false;

        float rx = Random.Range(-_moveDist, _moveDist);
        float rz = Random.Range(-_moveDist, _moveDist);

        _agent.destination = new Vector3(transform.position.x + rx, transform.position.y, transform.position.z + rz);
    }
}
