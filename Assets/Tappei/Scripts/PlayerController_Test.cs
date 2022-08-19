using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するテスト用スクリプト
/// </summary>
public class PlayerController_Test : MonoBehaviour
{
    Rigidbody _rb;

    LayerMask _mask;
    Vector3 _velo;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        float vert = Input.GetAxis("Vertical1P");
        float hori = Input.GetAxis("Horizontal1P");
        _velo = new Vector3(hori, 0, vert).normalized;

        if (_velo.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(_velo, Vector3.up);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _mask))
        {
            Debug.Log(hit.transform.position);
        }

        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
    }

    void FixedUpdate()
    {
        _rb.velocity = _velo * 3;
    }
}
