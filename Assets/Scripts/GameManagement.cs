using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// ゲーム全体を制御する
/// </summary>
public class GameManagement : MonoBehaviour
{
    //　タイトルボタンを押したら実行する
    public void TitleBackBottan()
    {
        print("a");
        SceneManager.LoadScene("TitleMenuScene");
    }
}
