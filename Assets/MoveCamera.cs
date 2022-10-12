using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    internal static Camera main;
    public GameObject player;
    internal float orthographicSize;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 1, -10);


        if (transform.position.x < 0)// 左
        {
            transform.position = new Vector3(0, 1, -10);
        }

        if (transform.position.x >= 500) //右
        {
            transform.position = new Vector3(500, 1, -10);
        }
    }
}
