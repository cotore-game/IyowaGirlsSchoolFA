using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGeneraeter : MonoBehaviour
{
    //GameObject
    public GameObject WaterDropInstance;

    //移動制限
    const float UPPER_GENERATE_POS = 6f;
    const float LEFT_GENERATE_POS = -8f;
    const float RIGHT_GENERATE_POS = 2.3f;

    [SerializeField,Tooltip("しずくが落ちるスピード")]
    private int FallSpeed = -3;

    //生成タイマー
    private float GenerateTimer = 0f; //生成するための刻み用
    public float IntervalTimer = 5f; //生成間隔

    private float NormalTimer = 0f;

    //フェーズ
    [SerializeField] private int PresentFase = 0;

    //Fase関数のフラグ
    bool isCalledOnce = false;

    private void Start()
    {
        SetNextFase(1); //初回フェーズ0→1
    }

    void Update()
    {
        //タイマー加算
        GenerateTimer += Time.deltaTime;
        NormalTimer += Time.deltaTime;


        if (GenerateTimer > IntervalTimer)
        {
            InstantiateWaterDrop(LEFT_GENERATE_POS, RIGHT_GENERATE_POS, UPPER_GENERATE_POS);
            GenerateTimer -= IntervalTimer;
        }

        if (!isCalledOnce) 
        {
            //時間で振り分け
            //めちゃくちゃ冗長だから、後で改善する
            if (NormalTimer < 15f)
            {
                SetNextFase(1);
            }
            else if (NormalTimer < 25f)
            {
                SetNextFase(2);
            }
            else
            {
                SetNextFase(3);
            }  
        }
    }

    public void InstantiateWaterDrop(float left, float right, float upper)
    {
        //インスタンスを生成する
        Instantiate(WaterDropInstance, new Vector2(Random.Range(left, right), upper), Quaternion.identity);

        Debug.Log("しずくの生成");
    }

    /// <summary>
    /// WaterControllerに渡す用の落ちるスピード変数
    /// </summary>
    /// <returns></returns>
    public float GetFallSpeed()
    {
        return FallSpeed;
    }

    /// <summary>
    /// 次のフェーズに移行する(難易度上昇)
    /// </summary>
    public void SetNextFase(int fase)
    {
        if (!(PresentFase > 3))
        {
            PresentFase = fase;
        }
        else Debug.LogWarning("フェーズの値が限界値");

        //ゲーム難易度
        switch (PresentFase)
        {
            case 1:
                Debug.Log("Fase1");
                FallSpeed = -3;
                IntervalTimer = 7f;
                break;

            case 2:
                Debug.Log("Fase2");
                FallSpeed = -7;
                IntervalTimer = 5f;
                break;

            case 3:
                Debug.Log("Fase3");
                FallSpeed = -15;
                IntervalTimer = 0.8f;
                break;
        }
    }
}
