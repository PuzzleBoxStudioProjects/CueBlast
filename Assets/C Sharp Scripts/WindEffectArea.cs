using UnityEngine;
using System.Collections;

public class WindEffectArea : MonoBehaviour
{
    public float windForce = 1000.0f;
	
	// Update is called once per frame
	void Update ()
    {
        //when player is in this trigger apply a fighting force
        if (WindEffect.instance.isInWindEffectArea)
        {
           WindEffect.instance.playerBall.AddForce(transform.forward * windForce, ForceMode.Force);
        }
	}
}
