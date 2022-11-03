using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 一方通行のオブジェクトワープ
/// </summary>
public class OneWayWarpPoint : MonoBehaviour
{
    GameObject obj;


    public OneWayWarpPoint transObj;


    Vector2 transVec;

    //移動状態を表すフラグ
    [SerializeField]
    bool moveStatus;//移動のみ

    void Start()
    {
        transVec = transObj.transform.position;

        //初期では移動可能なためTrue
        moveStatus = true;
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
        {

            //移動先は直後移動できないようにする 
            transObj.moveStatus = false;
            obj.transform.position = transVec;
        } // 移動
    }

    /// <summary>
    /// 物体と離れた直後呼ばれる 
    /// </summary>
    /// <param name="other">オブジェクト</param>
    void OnTriggerExit2D(Collider2D other)
    {
        //移動不可能にする。
        moveStatus = true;

    }
}
