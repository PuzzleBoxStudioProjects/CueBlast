using UnityEngine;
using System.Collections;

public class FuckYou : MonoBehaviour
{
    public AudioClip scoreSFX;

    public GameObject fireworks;

	void OnTriggerEnter (Collider col)
    {
        if (col.transform.tag == "OtherBalls")
        {
            Instantiate(fireworks, transform.position, transform.rotation);

            audio.PlayOneShot(scoreSFX);
        }
	}
}
