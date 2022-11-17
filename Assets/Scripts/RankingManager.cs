using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static DataCreateSave;
//using static System.Net.Mime.MediaTypeNames;

public class RankingManager : MonoBehaviour
{
    [SerializeField]
    Text displayField;
    //[SerializeField] Text inputName;
    [SerializeField]
    DataCreateSave datSave;
    //[SerializeField] Text[] names;
    //[SerializeField] Text[] scores;

    //string rankKey = "data";

    //[SerializeField]
    //List<Wepon> Weapons;

    //[System.Serializable]
    //class Wepon
    //{
    //    public List<string> name;
    //    public List<int> power;
    //    public List<int> defence;
    //}

    //public int score;

    void Start()
    {
        
    }

    public void OnClickRankingPush()
    {
        //PlayerPrefs.GetInt(datSave.scoreKey, 0);




        //foreach (var scoreke in datSave.scorekeys)
        //{
        //    Debug.Log("Loop");
        //}



        //for (int i = 0; i < datSave.scorekeys.Length; i++)
        //{
        //    Debug.Log("Loop") ;
        //    //PlayerPrefs.GetInt(datSave.scorekeys[i], 0);
        //    //PlayerPrefs.SetInt(datSave.scorekeys[i], datSave.Score);
        //    //PlayerPrefs.GetInt(datSave.namekeys[i], 0);
        //    //PlayerPrefs.SetInt(datSave.namekeys[i], datSave.Score);

        //    //for (int x = 0; x < scores.Length; x++)
        //    //{
        //    //    scores[x].text += datSave.Name.ToString() + "さん\t\t" + datSave.Score.ToString() + "\n";

        //    //    //displayField.text 
        //    //}

        //    //displayField.text += datSave.Name.ToString() + "さん\t\t" + datSave.Score.ToString() + "\n";
        //}

        //string rankers = "A 100\nB 120\nC 130";
        //displayField.text = rankers;

        //displayField.text += datSave.rankings.ToString();

        displayField.text = "";

        datSave.rankings.Sort((a, b) => b.score - a.score);
        //datSave.rankings.Clear();
        //datSave.rankings.Clear();

        

        foreach (var ranking in datSave.rankings)
        {
            displayField.text += ranking.name + "さん\n" +
                "Score：" + ranking.score.ToString() + "\n\n";
        }

        
        //displayField.text += datSave.Name.ToString() + "さん\t\t" + datSave.Score.ToString() + "\n";

        //PlayerPrefs.SetInt(datSave.scoreKey, datSave.Score);


        //PlayerPrefs.SetInt(datSave.scoreKey, datSave.Score);
        //List<DataCreateSave> datas = new List<DataCreateSave>();

        //for (int i = 0; i < datas.Count; i++)
        //{


        //    datas.Add(datas[i]);
        //}

        //Debug.Log(datas);

        //List<Score> datas = new List<Score>();

        //foreach (var score2 in datas)
        //{
        //    //datas += datSave.Score.ToString();
        //}



    }

    public void RoadButton()
    {
        Debug.Log("ロード");
        displayField.text = PlayerPrefs.GetString("data");
        //displayField.text += rankKey.ToString();
    }

    public void SaveButton()
    {
        Debug.Log("セーブ");
        PlayerPrefs.SetString("data", displayField.text);
    }

    public void ClearPanel()
    {
        Debug.Log("クリア");
        datSave.rankings.Clear();
        //displayField.text = "";
    }

    public void TitleBackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleMenuScene");
    }
}
