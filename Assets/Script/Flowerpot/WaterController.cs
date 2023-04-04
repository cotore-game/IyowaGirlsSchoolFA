using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private float FallSpeed = -3f;
    private WaterGeneraeter w;

    const float DeletePos = -6f;

    private void Start()
    {
        /*
        w = GetComponent<WaterGeneraeter>();
        FallSpeed = w.FallSpeed;
        Debug.Log(FallSpeed);
        */
    }

    private void Update()
    {
        transform.Translate(0f, FallSpeed * Time.deltaTime, 0f);

        if (transform.position.y < DeletePos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("“–‚½‚è”»’è");
        Destroy(gameObject);
    }
}
