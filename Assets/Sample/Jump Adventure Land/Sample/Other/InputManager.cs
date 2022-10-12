using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text
using System;
using UnityEngine.Networking;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Text inputName;

    /// <summary>
    /// Raises the click get json from www event.
    /// </summary>
    public void OnClickSetMessageApi()
    {
        
        SetJsonFromWww();
    }

    /// <summary>
    /// Sets the json from www.
    /// </summary>
    private void SetJsonFromWww()
    {
        // APIが設置してあるURLパス
        string sTgtURL = "http://localhost/Ranking/Ranking/setRanking"; // http://zipcloud.ibsnet.co.jp/api/search http://localhost/ChineseWushuRankingapi/Chinesewushuranking/setMessage
        string name = inputName.text; //Name


        // Wwwを利用して json データ取得をリクエストする
        StartCoroutine(SetMessage(sTgtURL, name)); //name , CallbackApiSuccess, CallbackWwwFailed
    }

    private IEnumerator SetMessage(string url, string name, Action<string> cbkSuccess = null, Action cbkFailed = null) // name  string popularity,string popularity, 
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name); //name name
        //form.AddField("popularity", popularity);

        // WWWを利用してリクエストを送る
        var webRequest = UnityWebRequest.Post(url, form);

        //タイムアウトの指定
        webRequest.timeout = 5;

        // WWWレスポンス待ち
        yield return webRequest.SendWebRequest();

        if (webRequest.error != null)
        {
            //レスポンスエラーの場合
            Debug.LogError(webRequest.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else if (webRequest.isDone)
        {



            // リクエスト成功の場合
            Debug.Log($"Success:{webRequest.downloadHandler.text}");
            if (null != cbkSuccess)
            {
                cbkSuccess(webRequest.downloadHandler.text);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
