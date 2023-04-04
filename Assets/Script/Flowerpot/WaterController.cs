using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private float DropFallSpeed = -3f;
    private WaterGeneraeter w;

    //仮のマネージャー格納変数
    public GameObject manager;

    const float DeletePos = -6f;

    private void Start()
    {
        //ゲッター関数で取得したい
        /*
        w = new WaterGeneraeter();
        DropFallSpeed = w.GetFallSpeed();
        */

        //仮
        manager = GameObject.Find("GameManager"); //重い
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
        Debug.Log("当たり判定");
        Destroy(gameObject);
    }


    /*
    public void UpdateFallSpeed()
    {
        DropFallSpeed = w.GetFallSpeed();
    }
    */
}
