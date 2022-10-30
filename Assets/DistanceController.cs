using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public GameObject objA;

    public GameObject objB;

    // Update is called once per frame
    void Update()
    {

        Vector3 cube = objA.transform.position;

        Vector3 sphere = objB.transform.position;

        float dis = Vector3.Distance(cube, sphere);

        if (dis > 2.0f)
        {
            Destroy(objA);
        }
    }
}
