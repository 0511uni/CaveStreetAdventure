using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    internal static Camera main;
    public GameObject player;
    internal float orthographicSize;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 640, -10);


        if (transform.position.x < 360)// 左
        {
            transform.position = new Vector3(360, 640, -10);
        }

        if (transform.position.x >= 1500) //右
        {
            transform.position = new Vector3(1500, 640, -10);
        }
    }
}
