using UnityEngine;
using System.Collections;

public class WindEffect : MonoBehaviour
{
    public static WindEffect instance;

    public bool isInWindEffectArea = false;

    public Rigidbody playerBall;

    void Awake()
    {
        instance = this;

        playerBall = rigidbody;
    }

    void OnTriggerEnter(Collider col)
    {
        //when entering the area of the wind effect turn this boolean on
        if (col.transform.tag == "WindEffect")
        {
            isInWindEffectArea = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "WindEffect")
        {
            isInWindEffectArea = false;
        }
    }
}
