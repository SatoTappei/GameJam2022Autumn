using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
{
    private GameObject[] _enemys;

    private void FixedUpdate()
    {
        SearchEnemy();
    }

    private void SearchEnemy()
    {
        _enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public Vector3 SearchNearEnemyDirection(Transform tr, float befo = 1000)
    {
        if (_enemys == null) return Vector3.zero;

        int index = 0;

        for(int i = 0; i < _enemys.Length; i++)
        {
            float dis = Vector3.Distance(_enemys[i].transform.position, tr.position);

            if(befo > dis)
            {
                befo = dis;
                index = i;
            }
        }

        if (index >= _enemys.Length) return Vector3.zero;

        return (_enemys[index].transform.position - tr.position).normalized;
    }
}
