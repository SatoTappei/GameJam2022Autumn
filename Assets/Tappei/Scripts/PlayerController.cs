using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度"), SerializeField] float _speed;
    [Header("プレイヤー1かどうか"), SerializeField] bool _isPlayer1;

    void Start()
    {
        
    }

    void Update()
    {
        float vert = Input.GetAxisRaw(_isPlayer1 ? "Vertical1P" : "Vertical2P") * Time.deltaTime * _speed;
        float hori = Input.GetAxisRaw(_isPlayer1 ? "Horizontal1P" : "Horizontal2P") * Time.deltaTime * _speed;
        transform.Translate(vert, 0, hori);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var objs = FindObjectsOfType<EnemyController>();
        //    objs.ToList().ForEach(o => o.StartChase(transform));
        //}
    }
}
