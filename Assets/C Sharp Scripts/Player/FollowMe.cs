using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FollowMe : MonoBehaviour
{
    public float minDistanceTilFollow = 20.0f,
                dist = 0.0f;

    public List<GameObject> initListOfBalls,
                            listOfBalls;

    public int testIndex = 0;

    public bool canAddTarget = false;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start ()
    {
        AddAllTargets();
	}

    void AddAllTargets()
    {
        initListOfBalls = new List<GameObject>(GameObject.FindGameObjectsWithTag("OtherBalls"));
    }

	// Update is called once per frame
	void Update ()
    {
        //Note: ONLY CALL THIS WHEN NEEDED SO IT DOESN'T CHECK THE FOREACH LOOP ALL THE TIME.
        Follow();
	}

    void Follow()
    {
        foreach (GameObject target in initListOfBalls)
        {
            dist = Vector3.Magnitude(target.transform.position - transform.position);

            if (dist <= minDistanceTilFollow)
            {
                if (!canAddTarget)
                {
                    //listOfBalls.Add(target);

                    target.renderer.material.color = Color.red;
                }
                canAddTarget = true;
            }
            else
            {
                canAddTarget = false;
            }
        }
    }
}
