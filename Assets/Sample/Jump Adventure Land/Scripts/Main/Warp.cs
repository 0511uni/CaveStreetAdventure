using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp : MonoBehaviour
{
    private GameObject obj;
    public Warp transObj;
    private Vector2 transVec;
    //移動状態を表すフラグ
    public bool moveStatus;//左右移動のみ

    void Start()
    {
        transVec = transObj.transform.position;

        //初期では移動可能なためTrue
        moveStatus = true;// 左右移動のみ
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        obj = GameObject.Find(other.name);
        //自分が移動可能なとき移動する。


        if(moveStatus)
        { // 左右移動のみ

            //移動先は直後移動できないようにする  // 左右移動のみ
            transObj.moveStatus = false; // 左右移動のみ
            obj.transform.position = transVec;
        } // 左右移動のみ
    }


    //物体と離れた直後呼ばれる // 左右移動のみ
    void OnTriggerExit2D(Collider2D other)
    {
            //移動可能にする。
            moveStatus = true;
        
    }
}