using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour
{
    private Vector3 orientation = Vector3.zero,
                    offset = Vector3.zero;

	void Awake ()
    {
        orientation = transform.rotation.eulerAngles;
        offset = transform.position - transform.parent.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = transform.parent.position + offset;
        transform.eulerAngles = orientation;
	}
}
