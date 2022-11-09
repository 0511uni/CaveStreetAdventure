using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// オブジェクトがワープする
/// 移動先オブジェクトのisTrigger外すと一方通行ができる。
/// </summary>
public class WarpPointUI : MonoBehaviour
{
    GameObject obj;

    RectTransform rectTransform;

    [Header("-----------------------------\n" +
        "【 一方通行を作る方法 】\n" +
        "移動先オブジェクトのコライダーの\n" +
        "isTriggerのチェックを外すだけ！\n" +
        "-----------------------------")]
    [Header("ワープさせる相手オブジェクト\n" +
        "※ 双方をアタッチ必須 ※")]
    public WarpPointUI transObj;

    Vector2 transVec;

    //移動状態を表すフラグ
    [Header("移動状態を表すフラグ")]
    [SerializeField]
    bool moveStatus;//移動のみ

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = transVec;
        
        transVec = transObj.rectTransform.anchoredPosition;

        //RectTransform rectTransform = transform as RectTransform;

        //transVec = rectTransform.anchoredPosition;s

        //transVec = transObj.anchoredPosition;

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
        //移動可能にする。
        moveStatus = true;

    }
}
