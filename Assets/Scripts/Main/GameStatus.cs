using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "GameStatus")]
public class GameStatus : ScriptableObject
{
    public int Score = 0;
    public string highScore = "High Score: ";
    public string key = "HIGH SCORE";
    public string Name = "Name:";
    public string scoreKey = "rankScore";
    public string[] scorekeys;
    public string[] namekeys;

    public List<Ranking> rankings;// = new List<Ranking>();

    //public List<Ranking> Rankers => rankings.OrderByDescending(Ranking => Ranking.score).ToList();


    [System.Serializable]
    public class Ranking
    {
        public string name;
        public int score;
        //public string timer;

        public Ranking(string nameValue, int score)
        {//, string timer
            name = nameValue;
            this.score = score;
            //this.timer = timer;
        }
        //public List<Ranking> Rankers => Ranking.OrderByDescending(Ranking => Ranking.score).ToList();

        //public string NameValue { get; }
    }
    public void Save()
    {
        var data = JsonUtility.ToJson(this, true);

        Debug.Log(data);

        PlayerPrefs.SetString("SaveData", data);

        //Debug.Log("セーブ");
        //PlayerPrefs.SetString("data", displayField.text);
    }

    public void Load()
    {
        var data = PlayerPrefs.GetString("SaveData");
    
        Debug.Log(data);

        JsonUtility.FromJsonOverwrite(data, this);
    }
}
