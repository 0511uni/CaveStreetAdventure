using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲームオーバーポイント
/// </summary>
public class PitfallsPoint : MonoBehaviour
{
    #region//インスペクターで設定する ゲームオーバー
    public Text gameOverText; // ゲームオーバーUI

    #endregion

    void Start()
    {
        gameOverText.enabled = false;
    }

    //void Update()
    //{
        
    //}

    //他のオブジェクトにぶつかった時に呼び出される
    void OnCollisionEnter2D(Collision2D other)
    {

        // 接触対象はPlayerタグですか？
        if (other.gameObject.CompareTag("Player"))
        {
            print("gameovr");
            //  リザルドの表示を最新
            gameOverText.enabled = true;
        }
    }
}
