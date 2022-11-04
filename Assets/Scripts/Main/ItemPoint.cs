using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム制御
/// </summary>
public class ItemPoint : MonoBehaviour
{
    /// <summary>
    /// 相手のコライダーと接触した時呼ばれる
    /// </summary>
    /// <param name="other">接触相手</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("atatta???");
            other.transform.Translate(0, -1, 0);
            transform.Translate(0, 1, 0);
            
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            //当たったオブジェクトを消す
            Destroy(gameObject);
        }
    }
}
