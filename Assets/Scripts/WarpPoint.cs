using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// オブジェクトがワープする
/// </summary>
public class WarpPoint : MonoBehaviour
{
    GameObject obj;

    [SerializeField]
    Warp transObj;

    Vector2 transVec;

    //移動状態を表すフラグ
    [SerializeField]
    bool moveStatus;//左右移動のみ

    void Start()
    {
        transVec = transObj.transform.position;

        //初期では移動可能なためTrue
        moveStatus = true;// 左右移動のみ
    }

    /// <summary>
    /// オブジェクトが引き金でイベントが発生する
    /// </summary>
    /// <param name="other">オブジェクト</param>
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
}
