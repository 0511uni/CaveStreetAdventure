using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 敵をジャンプして倒す敵ヘッドコライダー
/// </summary>
public class HeadController : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    /// <summary>
    /// 当たった時の処理
    /// </summary>
    /// <param name="collision">コライダー</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //enemy.GetComponent<BoxCollider2D>().enabled = false;
            //enemy.transform.Rotate(0, 0, 15);

            //　その収集アイテムを非表示にします
            enemy.SetActive(false);
        }
    }


}
