using UnityEngine;
using System.Collections;

public class ForceMeterPosition : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        transform.position = Vector2.zero;
        transform.localScale = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
        guiTexture.pixelInset = new Rect(Screen.width / 2, 0, 128, 160);
	}
}
