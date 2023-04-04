using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGeneraeter : MonoBehaviour
{
    //GameObject
    public GameObject WaterDropInstance;

    //�ړ�����
    const float UPPER_GENERATE_POS = 6f;
    const float LEFT_GENERATE_POS = -8f;
    const float RIGHT_GENERATE_POS = 2.3f;

    [SerializeField,Tooltip("��������������X�s�[�h")]
    private int FallSpeed = -3;

    //�����^�C�}�[
    private float GenerateTimer = 0f; //�������邽�߂̍��ݗp
    public float IntervalTimer = 5f; //�����Ԋu

    private float NormalTimer = 0f;

    //�t�F�[�Y
    [SerializeField] private int PresentFase = 0;

    //Fase�֐��̃t���O
    bool isCalledOnce = false;

    private void Start()
    {
        SetNextFase(1); //����t�F�[�Y0��1
    }

    void Update()
    {
        //�^�C�}�[���Z
        GenerateTimer += Time.deltaTime;
        NormalTimer += Time.deltaTime;


        if (GenerateTimer > IntervalTimer)
        {
            InstantiateWaterDrop(LEFT_GENERATE_POS, RIGHT_GENERATE_POS, UPPER_GENERATE_POS);
            GenerateTimer -= IntervalTimer;
        }

        if (!isCalledOnce) 
        {
            //���ԂŐU�蕪��
            //�߂��Ⴍ����璷������A��ŉ��P����
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
        //�C���X�^���X�𐶐�����
        Instantiate(WaterDropInstance, new Vector2(Random.Range(left, right), upper), Quaternion.identity);

        Debug.Log("�������̐���");
    }

    /// <summary>
    /// WaterController�ɓn���p�̗�����X�s�[�h�ϐ�
    /// </summary>
    /// <returns></returns>
    public float GetFallSpeed()
    {
        return FallSpeed;
    }

    /// <summary>
    /// ���̃t�F�[�Y�Ɉڍs����(��Փx�㏸)
    /// </summary>
    public void SetNextFase(int fase)
    {
        if (!(PresentFase > 3))
        {
            PresentFase = fase;
        }
        else Debug.LogWarning("�t�F�[�Y�̒l�����E�l");

        //�Q�[����Փx
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
