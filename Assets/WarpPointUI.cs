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
    [SerializeField]
    RectTransform end;

    //RectTransform obj;

    //RectTransform transVec;

    //[Header("-----------------------------\n" +
    //    "【 一方通行を作る方法 】\n" +
    //    "移動先オブジェクトのコライダーの\n" +
    //    "isTriggerのチェックを外すだけ！\n" +
    //    "-----------------------------")]
    //[Header("ワープさせる相手オブジェクト\n" +
    //    "※ 双方をアタッチ必須 ※")]
    //public WarpPointUI transObj;

    ////Vector2 transVec;

    ////移動状態を表すフラグ
    //[Header("移動状態を表すフラグ")]
    //[SerializeField]
    //bool moveStatus;//移動のみ

    void Start()
    {
        end = GetComponent<RectTransform>();


        //transVec = GetComponent<RectTransform>();

        ////transObj = GetComponent<RectTransform>();

        ////transVec.anchoredPosition = transObj;//rectTransform.anchoredPosition;

        ////transVec = transform as RectTransform;

        //transVec = transObj.transVec;

        ////transVec = transObj.transform.position;

        ////初期では移動可能なためTrue
        //moveStatus = true;
    }

    private void Update()
    {
        //  end.anchoredPosition += new Vector2(0, 5);//localPosition
        end.localPosition += Vector3.up * 1f;
    }

    /// <summary>
    /// オブジェクトが引き金でイベントが発生する
    /// </summary>
    /// <param name="other">オブジェクト</param>
    //void OnTriggerEnter2D(Collider2D hit)
    //{
    //    if (hit.CompareTag("end"))
    //    {
    //        Debug.Log("a");
    //        end.anchoredPosition += new Vector2(0, -700);
    //    }


        //obj = other.GetComponent<RectTransform>();
        ////obj = GameObject.Find(other.name);

        ////自分が移動可能なとき移動する。

        ////if (other.CompareTag("end"))
        ////{

        ////}


        //if (moveStatus)
        //{

        //    //移動先は直後移動できないようにする 
        //    transObj.moveStatus = false;
        //    obj = transVec;
        //} // 移動   
    //}//

    ///// <summary>
    ///// 物体と離れた直後呼ばれる 
    ///// </summary>
    ///// <param name="other">オブジェクト</param>
    //void OnTriggerExit2D(Collider2D other)
    //{
    //    //移動可能にする。
    //    moveStatus = true;

    //}
}
