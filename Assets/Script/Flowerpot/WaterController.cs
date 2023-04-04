using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private float DropFallSpeed = -3f;
    private WaterGeneraeter w;

    //���̃}�l�[�W���[�i�[�ϐ�
    public GameObject manager;

    const float DeletePos = -6f;

    private void Start()
    {
        //�Q�b�^�[�֐��Ŏ擾������
        /*
        w = new WaterGeneraeter();
        DropFallSpeed = w.GetFallSpeed();
        */

        //��
        manager = GameObject.Find("GameManager"); //�d��
        w = manager.GetComponent<WaterGeneraeter>();
        DropFallSpeed = w.GetFallSpeed();

        Debug.Log("DropFallSpeed: " + DropFallSpeed);
    }

    private void Update()
    {
        //DropFallSpeed = w.GetFallSpeed();

        transform.Translate(0f, DropFallSpeed * Time.deltaTime, 0f);

        if (transform.position.y < DeletePos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�����蔻��");
        Destroy(gameObject);
    }


    /*
    public void UpdateFallSpeed()
    {
        DropFallSpeed = w.GetFallSpeed();
    }
    */
}
