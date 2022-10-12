using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    //寿司を格納する変数
    public GameObject Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 sushiPos = Player.transform.position;

        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(sushiPos.x, 0, -10);
    }
}
