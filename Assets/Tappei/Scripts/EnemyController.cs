using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵の移動を制御する
/// プレイヤーが一定距離まで近づいたらプレイヤーのほうに寄ってきて
/// プレイヤーと離れていたらうろうろさせる
/// </summary>
public class EnemyController : MonoBehaviour
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
    /// <summary>プレイヤーを見失った際に別の地点へうろうろするまでの時間</summary>
    [Header("うろうろする際の止まっている時間"), SerializeField] float _randomWait;
    /// <summary>タイトル画面で使用するものか</summary>
    [Header("タイトル画面で使用するかものか"), SerializeField] bool _isTitle;
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
        SetMovePointRandom();
    }

    void Update()
    {
        if(!_isTitle)
        {
            float slimeDist = (transform.position - _slimeTrans.position).magnitude;
            float heroDist = (transform.position - _heroTrans.position).magnitude;

            // スライム、もしくは勇者との距離が指定された距離以下だったら追跡する
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

    /// <summary>ランダムな箇所に移動させる</summary>
    void MoveRandom()
    {
        // 目標地点の目前まで来たら
        if (!_agent.pathPending && _agent.remainingDistance < 0.1f && !_agent.isStopped)
        {
            // その地点で止めて、指定した秒後に次の地点へ移動させる
            _agent.isStopped = true;
            Invoke("SetMovePointRandom", _randomWait);
        }
    }

    /// <summary>ランダムな位置に移動させる</summary>
    void SetMovePointRandom()
    {
        _agent.isStopped = false;

        float rx = Random.Range(-5.0f, 5.0f);
        float rz = Random.Range(-5.0f, 5.0f);

        _agent.destination = new Vector3(transform.position.x + rx, transform.position.y, transform.position.z + rz);
    }
}