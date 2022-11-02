using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClauseWallOpening : MonoBehaviour
{
    /// <summary>
    /// 他のオブジェクトにぶつかった時に呼び出される
    /// </summary>
    /// <param name="other">ぶつかった相手</param>
    void OnCollisionEnter2D(Collision2D other)
    {

        // 接触対象はPlayerタグですか？
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
