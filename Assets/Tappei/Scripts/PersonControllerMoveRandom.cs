using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 村人の移動を制御する
/// ランダムに移動して、プレイヤーが近づいてきたら速度を上げてうろうろする
/// </summary>
public class PersonControllerMoveRandom : MonoBehaviour
{
    NavMeshAgent _agent;
    /// <summary>スライムのタグ</summary>
    [Header("スライムのタグ"), SerializeField] string _slimeTag;
    /// <summary>勇者のタグ</summary>
    [Header("勇者のタグ"), SerializeField] string _heroTag;
    /// <summary>移動速度</summary>
    [Header("移動速度"), SerializeField] float _speed;
    /// <summary>逃走する際のスピードの移動速度</summary>
    [Header("逃走する際の移動速度"), SerializeField] float _escapeSpeed;
    /// <summary>移動後の待機時間</summary>
    [Header("移動後の待機時間"), SerializeField] float _standby;
    /// <summary>逃走する際の移動後の待機時間</summary>
    [Header("逃走する際の移動後の待機時間"), SerializeField] float _escapeStandby;
    /// <summary>敵がプレイヤー認知する距離</summary>
    [Header("敵がプレイヤーを認知する距離"), SerializeField] float _distance;
    /// <summary>一回の移動距離</summary>
    [Header("一回の移動距離"), SerializeField] float _moveDist;
    /// <summary>スライムとの距離を計算するのに必要なTransform</summary>
    Transform _slimeTrans;
    /// <summary>勇者との距離を計算するのに必要なTransform</summary>
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
        // スポーン時にランダムな地点へ移動させる
        MoveRandomPoint();
    }

    void Update()
    {
        // スライムと自身、勇者と自身の距離を測る
        float slimeDist = (transform.position - _slimeTrans.position).magnitude;
        float heroDist = (transform.position - _heroTrans.position).magnitude;
        // スライムもしくは勇者と自身距離が一定以下なら逃げる状態にする
        bool isEscape = slimeDist < _distance || heroDist < _distance;
        // 逃げる状態ら速度を上げ、移動後の待機時間を短くする
        _agent.speed = isEscape ? _escapeSpeed : _speed;
        _standby = isEscape ? _escapeStandby : _standby;

        // 目標地点の目前まで来たら
        if (!_agent.pathPending && _agent.remainingDistance < 0.1f && !_agent.isStopped)
        {
            // その地点で止めて、指定した秒後に次の地点へ移動させる
            _agent.isStopped = true;
            Invoke("MoveRandomPoint", _standby);
        }
    }

    /// <summary>ランダムな位置に移動させる</summary>
    void MoveRandomPoint()
    {
        _agent.isStopped = false;

        float rx = Random.Range(-_moveDist, _moveDist);
        float rz = Random.Range(-_moveDist, _moveDist);

        _agent.destination = new Vector3(transform.position.x + rx, transform.position.y, transform.position.z + rz);
    }
}
