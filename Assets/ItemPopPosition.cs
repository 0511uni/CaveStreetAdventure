using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// アイテムが出現する
/// </summary>
public class ItemPopPosition : MonoBehaviour
{
    [SerializeField]
    GameObject item;

    /// <summary>
    /// トリガーとの接触時に呼ばれるコールバック
    /// </summary>
    /// <param name="hit">接触した相手</param>
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Wellに当たったら
        if (hit.CompareTag("Wall"))
        {
            item.transform.Translate(0, 2, 0);
        }     
    }
}
