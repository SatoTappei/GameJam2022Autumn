using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSplit : MonoBehaviour
{
    [SerializeField]
    private int _splitMaxCount = 4;
    [SerializeField]
    private GameObject _splitPrefab;

    private int _count = 0;

    public void Split()
    {
        _count++;
        Debug.Log(_count);

        if( _count >= _splitMaxCount )
        {
            _count = 0;

            Vector3 pos = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z); 
            Instantiate(_splitPrefab, pos, Quaternion.identity);
        }
    }
}
