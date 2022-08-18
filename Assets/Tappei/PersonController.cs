using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ���l�̈ړ��𐧌䂷��
/// �����_���Ɉړ����āA�v���C���[���߂Â��Ă������ԉ����p�Ɍ������Ĉړ�����
/// </summary>
public class PersonController : MonoBehaviour
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
    /// <summary>�����n�_�̃^�O</summary>
    [Header("�����n�_�̃^�O"), SerializeField] string _escapePointTag;
    /// <summary>�v���C���[�����������ۂɕʂ̒n�_�ւ��낤�낷��܂ł̎���</summary>
    [Header("���낤�낷��ۂ̎~�܂��Ă��鎞��"), SerializeField] float _randomWait;
    /// <summary>��������ۂ̃X�s�[�h�̔{��</summary>
    [Header("��������ۂ̃X�s�[�h�̔{��"), SerializeField] float _escapeSpeedMag;
    /// <summary>�X���C���Ƃ̋������v�Z����̂ɕK�v��Transform</summary>
    Transform _slimeTrans;
    /// <summary>�E�҂Ƃ̋������v�Z����̂ɕK�v��Transform</summary>
    Transform _heroTrans;
    /// <summary>���������ǂ���</summary>
    bool _isEscape;

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
        float slimeDist = (transform.position - _slimeTrans.position).magnitude;
        float heroDist = (transform.position - _heroTrans.position).magnitude;

        // �X���C���A�������͗E�҂Ƃ̋������w�肳�ꂽ�����ȉ���������
        if (slimeDist < _distance || heroDist < _distance)
        {
            // �������łȂ�������
            if (!_isEscape)
            {
                // �����t���O�𗧂Ă�
                _isEscape = true;
                // �������͑��x���グ��
                _agent.speed *= 2;

                // �߂��ق��̑O�������擾����
                Transform target = slimeDist < heroDist ? _slimeTrans : _heroTrans;
                // �߂��ق��̑O�������烌�C���΂�
                
                // �X�e�[�W�̒[�ɂԂ�������
                // ���̈ʒu�Ɉړ�����
            }
        }
        else
        {
            // �ڕW�n�_�̖ڑO�܂ŗ�����
            if (!_agent.pathPending && _agent.remainingDistance < 0.1f && !_agent.isStopped)
            {
                // ���̒n�_�Ŏ~�߂āA�w�肵���b��Ɏ��̒n�_�ֈړ�������
                _agent.isStopped = true;
                Invoke("MoveRandomPoint", _randomWait);
            }
        }
    }

    /// <summary>�����_���Ȉʒu�Ɉړ�������</summary>
    void MoveRandomPoint()
    {
        _agent.isStopped = false;

        float rx = Random.Range(-5.0f, 5.0f);
        float rz = Random.Range(-5.0f, 5.0f);

        _agent.destination = new Vector3(transform.position.x + rx, transform.position.y, transform.position.z + rz);
    }
}
