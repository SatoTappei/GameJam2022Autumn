using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IsActive : MonoBehaviour
{
    [SerializeField]
    GameObject[] fademanager = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {

        }
        else
        {
            for(int i = 0; i < fademanager.Length; i++)
            {
                fademanager[i].SetActive(false);
            }
        }
    }
}
