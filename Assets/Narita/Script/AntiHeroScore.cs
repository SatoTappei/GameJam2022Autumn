using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiHeroScore : MonoBehaviour//����̓X���C��
{
    /// <summary>
    /// �A���`�q�[���[�̍��v�X�R�A
    /// </summary>
    private int antiheroscore = 0;
    /// <summary>
    /// ���Z�X�R�A
    /// </summary>
    [SerializeField]
    int score = 50;
    [SerializeField]
    int minusheroscore = 20;
    public int Antiheroscore { get => antiheroscore; set => antiheroscore = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("�����̃^�O"))
        {
            antiheroscore += score;
        }
        if (other.gameObject.CompareTag("���l�̃^�O"))
        {
            //�E�҂̃X�R�A������
        }
    }
}
