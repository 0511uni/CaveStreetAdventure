using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text
using System;
using UnityEngine.Networking;

/// <summary>
/// Manager main.
/// </summary>
public class ManagerMain : MonoBehaviour
{
    [SerializeField] private Text displayField;
    [SerializeField] private Text inputName;
    int count = 1;
    //[SerializeField] private Text inputScore;

    public PlayerController_J playerController = new PlayerController_J();
    //public Timer timer = new Timer();

    /// <summary>
    /// Raises the click clear display event.
    /// </summary>
    public void OnClickClearDisplay()
    {
        displayField.text = " ";
    }

    /// <summary>
    /// Raises the click get json from www event.
    /// </summary>
    public void OnClickGetMessagesApi()
    {
        displayField.text = "待っててね\nwait...";
        GetJsonFromWww();
    }

    /// <summary>
    /// Raises the click get json from www event.
    /// </summary>
    public void OnClickSetMessageApi()
    {
        displayField.text = "待っててね\nwait...";
        SetJsonFromWww();
    }

    /// <summary>
    /// Gets the json from www.
    /// </summary>
    private void GetJsonFromWww()
    {
        // APIが設置してあるURLパス
        const string url = "http://localhost/Ranking/Ranking/getRankings"; // http://localhost/ChineseWushuRankingapi/Chinesewushuranking/getMessages http://zipcloud.ibsnet.co.jp/api/search


        // Wwwを利用して json データ取得をリクエストする
        //StartCoroutine(GetMessages(url, CallbackWwwSuccess, CallbackWwwFailed));
    }

    /// <summary>
    /// Callbacks the www success.
    /// </summary>
    /// <param name="response">Response.</param>
    private void CallbackWwwSuccess(string response)
    {
        // json データ取得が成功したのでデシリアライズして整形し画面に表示する
        List<MessageData> messageList = MessageDataModel.DeserializeFromJson(response);

        string sStrOutput = "";
        foreach (MessageData message in messageList)
        {
            sStrOutput += "♦ " + count.ToString() + "位  ♦\n";
            sStrOutput += $"Name:　{message.Name}　  ";
            sStrOutput += $"Score:　{message.Score}\n";
            //sStrOutput += $"Data: {message.Data}\n\n\n";
            sStrOutput += $"Data:　{message.Data.Replace("T", " ").Replace("+00:00", " ")}\n\n";

            //$"" ++$"string Data = "yyyy-MM-DDTHH:mm:ss+00:00".ToString(); 
            //string str2 = sStrOutput.Replace($"Data: {message.Data}\n\n\n", "yyyy-MM-DD HH:mm:ss"); //yyyy - MM - DDTHH:mm: ss + 00:00", "yyyy - MM - DD HH: mm: ss
            if(count < 5)
            {
                count++;
            } else
            {
                count = 1;
            }
            


            #region //編集要素コメント
            //sStrOutput += $"Popularity:{message.Popularity}\n"; 

            // sStrOutput += $"Message:{message.address1}\n";
            // sStrOutput += $"Message:{message.address2}\n";
            // sStrOutput += $"Message:{message.address3}\n";
            // sStrOutput += $"Message:{message.kana1}\n";
            // sStrOutput += $"Message:{message.kana2}\n";
            // sStrOutput += $"Message:{message.kana3}\n";
            // sStrOutput += $"Message:{message.prefcode}\n";
            // sStrOutput += $"zipcode:{message.zipcode}\n";
        }
        //address1
        //address2
        //address3
        //kana1
        //kana2
        //kana3
        //prefcode
        //zipcode
        #endregion

        displayField.text = sStrOutput;
    }

    /// <summary>
    /// Callbacks the www failed.
    /// </summary>
    private void CallbackWwwFailed()
    {
        // jsonデータ取得に失敗した
        displayField.text = "もう1回試して\nみて！";
    }

    /// <summary>
    /// Callbacks the API success.
    /// </summary>
    /// <param name="response">Response.</param>
    private void CallbackApiSuccess(string response)
    {
        // json データ取得が成功したのでデシリアライズして整形し画面に表示する
        displayField.text = response;
    }

    /// <summary>
    /// Downloads the json.
    /// </summary>
    /// <returns>The json.</returns>
    /// <param name="url">S tgt UR.</param>
    /// <param name="cbkSuccess">Cbk success.</param>
    /// <param name="cbkFailed">Cbk failed.</param>
    //private IEnumerator GetMessages(string url, Action<string> cbkSuccess = null, Action cbkFailed = null)
    //{
        //// WWWを利用してリクエストを送る
        //var webRequest = UnityWebRequest.Get(url);

        ////タイムアウトの指定
        //webRequest.timeout = 80; //15

        //// WWWレスポンス待ち
        ////yield return webRequest.SendWebRequest();

        //if (webRequest.error != null)
        //{
        //    //レスポンスエラーの場合
        //    Debug.LogError(webRequest.error);
        //    if (null != cbkFailed)
        //    {
        //        cbkFailed();
        //    }
        //}
        //else if (webRequest.isDone)
        //{
        //    // リクエスト成功の場合
        //    Debug.Log($"Success:{webRequest.downloadHandler.text}");
        //    if (null != cbkSuccess)
        //    {
        //        cbkSuccess(webRequest.downloadHandler.text);
        //    }
        //}
    //}

    /// <summary>
    /// Response the check for time out WWW.
    /// </summary>
    /// <returns>The check for time out WWW.</returns>
    /// <param name="webRequest">Www.</param>
    /// <param name="timeout">Timeout.</param>
    private IEnumerator ResponseCheckForTimeOutWWW(UnityWebRequest webRequest, float timeout)
    {
        float requestTime = Time.time;

        while (!webRequest.isDone)
        {
            if (Time.time - requestTime < timeout)
            {
                yield return null;
            }
            else
            {
                Debug.LogWarning("TimeOut"); //タイムアウト
                break;
            }
        }

        yield return null;
    }


    /// <summary>
    /// Sets the json from www.
    /// </summary>
    private void SetJsonFromWww()
    {
        // APIが設置してあるURLパス
        string sTgtURL = "http://localhost/Ranking/Ranking/setRanking"; // http://zipcloud.ibsnet.co.jp/api/search http://localhost/ChineseWushuRankingapi/Chinesewushuranking/setMessage
        string name = inputName.text; //Name
        string Score = playerController.score.ToString();
       



        //string Data = Timer.time.ToString();


        // string address1 = inputName.text; //Name
        // string address2 = inputName.text; //Name
        // string address3 = inputName.text; //Name
        // string kana1 = inputName.text; //Name
        // string kana2 = inputName.text; //Name
        // string kana3 = inputName.text; //Name
        // string prefcode = inputName.text; //Name
        // string zipcode = inputName.text; //Name
        // string message = inputMessage.text;

        //address1
        //address2
        //address3
        //kana1
        //kana2
        //kana3
        //prefcode
        //zipcode

        // Wwwを利用して json データ取得をリクエストする
        StartCoroutine(SetMessage(sTgtURL, name, Score,CallbackApiSuccess, CallbackWwwFailed)); //name popularity,
    }

    /// <summary>
    /// Sets the message.
    /// </summary>
    /// <returns>The message.</returns>
    /// <param name="url">URL target.</param>
    /// <param name="name">Name.</param>
    /// <param name="popularity">Popularity.</param>
    /// <param name="cbkSuccess">Cbk success.</param>
    /// <param name="cbkFailed">Cbk failed.</param>
    private IEnumerator SetMessage(string url, string Name, string Score,Action<string> cbkSuccess = null, Action cbkFailed = null) // name  string Score,
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", Name); //name name
        form.AddField("Score", Score);

        // WWWを利用してリクエストを送る
        var webRequest = UnityWebRequest.Post(url, form);

        //タイムアウトの指定
        webRequest.timeout = 80; //3

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
}