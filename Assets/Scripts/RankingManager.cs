using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Text displayField;
    [SerializeField] Text inputName;
    [SerializeField] DataCreateSave datSave;
    //[SerializeField] GameObject[] gameObjects;

    //public int score;

    public void OnClickRankingPush()
    {
        PlayerPrefs.GetInt(datSave.scoreKey, 0);

        PlayerPrefs.SetInt(datSave.scoreKey, datSave.Score);

        for (int i = 0; i < datSave.keys.Length; i++)
        {
            PlayerPrefs.GetInt(datSave.keys[i], 0);
            PlayerPrefs.SetInt(datSave.keys[i], datSave.Score);

            displayField.text += datSave.Name.ToString() + "さん\t\t" + datSave.Score.ToString() + "\n";
        }


        //displayField.text += datSave.Name.ToString() + "さん\t\t" + datSave.Score.ToString() + "\n";


        //List<DataCreateSave> datas = new List<DataCreateSave>();

        //for (int i = 0; i < datas.Count; i++)
        //{


        //    datas.Add(datas[i]);
        //}

        //Debug.Log(datas);

        List<Score> datas = new List<Score>();

        foreach (var score2 in datas)
        {
            //datas += datSave.Score.ToString();
        }



    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
