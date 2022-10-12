using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemController : MonoBehaviour
{

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter2D(Collider2D hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            // 何らかの処理
            //当たったオブジェクトを消す
            Destroy(this.gameObject);
        }
    }
}
