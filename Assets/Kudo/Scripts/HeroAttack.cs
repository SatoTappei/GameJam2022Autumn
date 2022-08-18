using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] int _heroScore;
    private BoxCollider _attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        _attackCollider = GameObject.Find("Sword").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(_heroScore);
            FindObjectOfType<GameManager>().HeroScore(_heroScore);
        }
    }

    public void OnAttack()
    {
        _attackCollider.enabled = true;
    }
    public void OffAttack()
    {
        _attackCollider.enabled = false;
    }
}
