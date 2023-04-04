using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    //GameObject
    public GameObject WaterDropInstance;
    Vector2 position;

    //移動制限
    const float UPPER_GENERATE_POS = 6f;
    const float LEFT_GENERATE_POS = -8f;
    const float RIGHT_GENERATE_POS = 2.3f;

    public int FallSpeed = 8;

    //生成タイマー
    private float Timer = 0f;

    //フェーズ
    [SerializeField] private int PresentFase = 1;

    void Update()
    {
        Timer += Time.deltaTime;
        position = WaterDropInstance.transform.position;

        //ゲーム難易度
        switch (PresentFase)
        {
            case 1:
                //Debug.Log("Fase1");
                FallSpeed = 8;
                break;

            case 2:
                //Debug.Log("Fase2");
                FallSpeed = 10;
                break;

            case 3:
                //Debug.Log("Fase3");
                FallSpeed = 15;
                break;
        }

        if(Timer > 10f)
        {
            InstantiateWaterDrop(LEFT_GENERATE_POS, RIGHT_GENERATE_POS, UPPER_GENERATE_POS);
            Timer -= 10f;
        }

        position.y -= FallSpeed * Time.deltaTime;
    }

    public void InstantiateWaterDrop(float left, float right, float upper)
    {
        //インスタンスを生成する
        Instantiate(WaterDropInstance, new Vector2(Random.Range(left, right), upper), Quaternion.identity);
    }
}
