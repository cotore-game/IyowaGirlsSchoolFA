using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //�g�p����Q�[���I�u�W�F�N�g
    public GameObject FlowerPot;

    //�ړ��X�s�[�h
    public int MoveSpeed = 5;
    public int FallSpeed = 8;

    Vector2 position;

    //�ړ�����
    const float LEFTMOVE_LIMIT_POS = -7.7f;
    const float RIGHTMOVE_LIMIT_POS = 2.3f;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        position = FlowerPot.transform.position;

        //�ړ�
        if (Input.GetKey("left"))
        {
            position.x -= MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            position.x += MoveSpeed * Time.deltaTime;
        }

        FlowerPot.transform.position = position;
    }
}
