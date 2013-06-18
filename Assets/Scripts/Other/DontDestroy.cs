using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour
{

	void Awake ()
	{
		if (this.transform == null)
		{
			DontDestroyOnLoad(transform.gameObject);
		}
	}
}
