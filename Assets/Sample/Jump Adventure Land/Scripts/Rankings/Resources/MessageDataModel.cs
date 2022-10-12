using System.Collections;
using System.Collections.Generic;
using MiniJSON;		// Json

/// <summary>
/// Json response manager.
/// </summary>
public class MessageDataModel{

	/// <summary>
	/// Deserialize from json.
	/// MessageData型のリストがjsonに入っていると仮定して
	/// </summary>
	/// <returns>The from json.</returns>
	/// <param name="sStrJson">S string json.</param>
	public static List<MessageData> DeserializeFromJson(string sStrJson){
		var	ret	= new List<MessageData> ();

		// JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
		IList jsonList = (IList)Json.Deserialize(sStrJson);

		// リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
		foreach (IDictionary jsonOne in jsonList) {

			//新レコード解析開始
			var	tmp = new MessageData ();

			if (jsonOne.Contains ("Name")) { // Name
				tmp.Name	= (string)jsonOne ["Name"]; // Name
			}
            if (jsonOne.Contains("Score")) {
                tmp.Score = ((long)jsonOne["Score"]).ToString();
            }
            if (jsonOne.Contains("Data"))
            {
                tmp.Data = (string)jsonOne["Data"];
            }



            #region //編集要素コメント

            //if (jsonOne.Contains("Data"))
            //{
            //    tmp.Data = ((long)jsonOne["Data"]).ToString();
            //}

            //         if (jsonOne.Contains ("Popularity")) {
            //	tmp.Popularity	= (string)jsonOne ["Popularity"];
            //}

            // if (jsonOne.Contains ("address1")) { // Name
            // 	tmp.address1	= (string)jsonOne ["address1"]; // Name
            // }
            // if (jsonOne.Contains ("address2")) { // Name
            // 	tmp.address2	= (string)jsonOne ["address2"]; // Name
            // }
            // if (jsonOne.Contains ("address3")) { // Name
            // 	tmp.address3	= (string)jsonOne ["address3"]; // Name
            // }
            // if (jsonOne.Contains ("kana1")) {
            // 	tmp.kana1	= (string)jsonOne ["kana1"];
            // }
            // if (jsonOne.Contains ("kana2")) {
            // 	tmp.kana1	= (string)jsonOne ["kana1"];
            // }
            // if (jsonOne.Contains ("kana3")) {
            // 	tmp.kana1	= (string)jsonOne ["kana3"];
            // }
            // if (jsonOne.Contains ("prefcode")) {
            // 	tmp.prefcode	= (string)jsonOne ["prefcode"];
            // }
            // if (jsonOne.Contains ("zipcode")) {
            // 	tmp.zipcode	= (string)jsonOne ["zipcode"];
            // }
            // if (jsonOne.Contains ("Date")) {
            // 	tmp.Date	= (string)jsonOne ["Date"];
            // }

            //address1
            //address2
            //address3
            //kana1
            //kana2
            //kana3
            //prefcode
            //zipcode

            #endregion



            //現レコード解析終了
            ret.Add (tmp);
		}
		return ret;
	}
}
