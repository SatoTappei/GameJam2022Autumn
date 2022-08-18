using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [SerializeField]
    SlimeSplit _slimeSplit;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IHittable>(out IHittable hittable))
        {
            hittable.Hit(gameObject);
            _slimeSplit.Split();
        }
    }
}
