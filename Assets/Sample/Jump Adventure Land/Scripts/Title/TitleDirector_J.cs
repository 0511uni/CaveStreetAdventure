using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleDirector_J : MonoBehaviour {

	//　スタートボタンを押したら実行する
    public void GameStart() {
		print("a");
            SceneManager.LoadScene ("Main_Jump Adventure Land");
	}

    //　RANKING Buttonを押したら実行する
    public void RankingStart()
    {
        print("b");
        SceneManager.LoadScene("Ranking_Jump Adventure Land");
    }

    //　ゲーム終了ボタンを押したら実行する
    public void GameEnd() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://www.yahoo.co.jp/");
#else
        Application.Quit();
#endif
    }

    // Use this for initialization
    void Start () {
        Screen.SetResolution(400, 710, false, 60);
    }

    #region //編集要素コメント

    // Update is called once per frame
    void Update () {
		
	}

    #endregion

}
