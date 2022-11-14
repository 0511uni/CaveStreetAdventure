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

    public void OnClickRankingPush()
    {
        displayField.text += datSave.Name.ToString() + "さん\t\t" + PlayerPrefs.GetInt(datSave.scoreKey).ToString() + "\n";


        //List<DataCreateSave> datas = new List<DataCreateSave>();

        //for (int i = 0; i < datas.Count; i++)
        //{
            

        //    datas.Add(datas[i]);
        //}

        //Debug.Log(datas);

        //foreach (var score in scores)
        //{
        //    score += datSave.Score.ToString();
        //}



    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
