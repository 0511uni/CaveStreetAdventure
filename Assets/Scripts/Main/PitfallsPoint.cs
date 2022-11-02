using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// ゲームオーバーポイント
/// </summary>
public class PitfallsPoint : MonoBehaviour
{
    #region//インスペクターで設定する ゲームオーバー

    [SerializeField]
    GameManagement GameManagement;

    #endregion

    /// <summary>
    /// 他のオブジェクトにぶつかった時に呼び出される
    /// </summary>
    /// <param name="other">ぶつかった相手</param>
    void OnCollisionEnter2D(Collision2D other)
    {

        // 接触対象はPlayerタグですか？
        if (other.gameObject.CompareTag("Player"))
        {

            GameManagement.GameOver();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
        }
    }
}
