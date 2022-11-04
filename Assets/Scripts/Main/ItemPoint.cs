using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// アイテムコントローラー
/// </summary>
public class ItemPoint : MonoBehaviour
{
    //// トリガーとの接触時に呼ばれるコールバック
    //void OnTriggerEnter2D(Collider2D hit)
    //{
    //    // 接触対象はPlayerタグですか？
    //    if (hit.CompareTag("Player"))
    //    {
            
    //    }

        
    //}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("atatta???");
            transform.Translate(0, 1, 0);
            other.transform.Translate(0, -1, 0);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            //当たったオブジェクトを消す
            Destroy(this.gameObject);
        }
    }
}
