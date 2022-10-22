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



    //void Start()
    //{

    //}

    //void Update()
    //{

    //}

    //他のオブジェクトにぶつかった時に呼び出される
    void OnCollisionEnter2D(Collision2D other)
    {

        // 接触対象はPlayerタグですか？
        if (other.gameObject.CompareTag("Player"))
        {

            GameManagement.GameOver();
        }
    }
}
