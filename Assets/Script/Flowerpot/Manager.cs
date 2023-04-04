using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //使用するゲームオブジェクト
    public GameObject FlowerPot;

    //移動スピード
    public int MoveSpeed = 5;
    public int FallSpeed = 8;

    Vector2 position;

    //移動制限
    const float LEFTMOVE_LIMIT_POS = -7.7f;
    const float RIGHTMOVE_LIMIT_POS = 2.3f;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        position = FlowerPot.transform.position;

        //移動
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
