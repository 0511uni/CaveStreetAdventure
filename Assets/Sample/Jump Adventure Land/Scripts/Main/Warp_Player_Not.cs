using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp_Player_Not : MonoBehaviour
{
    private GameObject obj;
    public Warp_Player_Not transObj;
    private Vector2 transVec;
    //移動状態を表すフラグ
    public bool moveStatus;//左右移動のみ

    void Start()
    {
        transVec = transObj.transform.position;


        moveStatus = true;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        obj = GameObject.Find(other.name);
        //自分が移動可能なとき移動する。


        if (moveStatus)
        { // 左右移動のみ

            //移動先は直後移動できないようにする  // 左右移動のみ
            transObj.moveStatus = false; // 左右移動のみ
            obj.transform.position = transVec;
        } // 左右移動のみ



    }


    //物体と離れた直後呼ばれる // 左右移動のみ
    void OnTriggerExit2D(Collider2D other)
    {
        //// 接触対象はPlayerタグですか？
        //if (other.CompareTag("Player"))
        //{

            
        //}
        //else
        //{
            //移動可能にする。
            moveStatus = true;
        //}

    }
}
