using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour, IHittable
{
    [SerializeField]
    SlimeSplit _slimeSplit;
    
    private AntiHeroController _slimeMove;


    private void Start()
    {
        _slimeMove = GetComponent<AntiHeroController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IHittable>(out IHittable hittable))
        {
            hittable.Hit(gameObject);
            _slimeSplit.Split();
        }
    }

    public void Hit(GameObject go)
    {
        if(go.tag == "Hero")
        {
            _slimeMove.Stun();
        }
    }
}
