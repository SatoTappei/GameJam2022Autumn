using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 村人の移動を制御する
/// ランダムに移動して、プレイヤーが近づいてきたら一番遠い角に向かって移動する
/// </summary>
public class PersonController : MonoBehaviour
{
    NavMeshAgent _agent;
    /// <summary>移動速度</summary>
    [Header("移動速度"), SerializeField] float _speed;
    /// <summary>敵がプレイヤー認知する距離</summary>
    [Header("敵がプレイヤーを認知する距離"), SerializeField] float _distance;
    /// <summary>スライムのタグ</summary>
    [Header("スライムのタグ"), SerializeField] string _slimeTag;
    /// <summary>勇者のタグ</summary>
    [Header("勇者のタグ"), SerializeField] string _heroTag;
    /// <summary>逃走地点のタグ</summary>
    [Header("逃走地点のタグ"), SerializeField] string _escapePointTag;
    /// <summary>プレイヤーを見失った際に別の地点へうろうろするまでの時間</summary>
    [Header("うろうろする際の止まっている時間"), SerializeField] float _randomWait;
    /// <summary>逃走する際のスピードの倍率</summary>
    [Header("逃走する際のスピードの倍率"), SerializeField] float _escapeSpeedMag;
    /// <summary>スライムとの距離を計算するのに必要なTransform</summary>
    Transform _slimeTrans;
    /// <summary>勇者との距離を計算するのに必要なTransform</summary>
    Transform _heroTrans;
    /// <summary>逃走中かどうか</summary>
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
        // スポーン時にランダムな地点へ移動させる
        MoveRandomPoint();
    }

    void Update()
    {
        float slimeDist = (transform.position - _slimeTrans.position).magnitude;
        float heroDist = (transform.position - _heroTrans.position).magnitude;

        // スライム、もしくは勇者との距離が指定された距離以下だったら
        if (slimeDist < _distance || heroDist < _distance)
        {
            // 逃走中でなかったら
            if (!_isEscape)
            {
                // 逃走フラグを立てる
                _isEscape = true;
                // 逃走時は速度を上げる
                _agent.speed *= 2;

                // 近いほうの前向きを取得する
                Transform target = slimeDist < heroDist ? _slimeTrans : _heroTrans;
                // 近いほうの前向きからレイを飛ばす
                
                // ステージの端にぶち当たる
                // その位置に移動する
            }
        }
        else
        {
            // 目標地点の目前まで来たら
            if (!_agent.pathPending && _agent.remainingDistance < 0.1f && !_agent.isStopped)
            {
                // その地点で止めて、指定した秒後に次の地点へ移動させる
                _agent.isStopped = true;
                Invoke("MoveRandomPoint", _randomWait);
            }
        }
    }

    /// <summary>ランダムな位置に移動させる</summary>
    void MoveRandomPoint()
    {
        _agent.isStopped = false;

        float rx = Random.Range(-5.0f, 5.0f);
        float rz = Random.Range(-5.0f, 5.0f);

        _agent.destination = new Vector3(transform.position.x + rx, transform.position.y, transform.position.z + rz);
    }
}
