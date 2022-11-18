using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "GameStatus")]
public class GameStatus : ScriptableObject
{
    public int Score = 0;
    public string highScore = "High Score: ";
    public string key = "HIGH SCORE";

    private List<Ranking> rankings;// = new List<Ranking>();

    public List<Ranking> Rankings
    {
        get => rankings; set
        {
            for (int i = 0; i < 5; i++)
            {

            }
            rankings = value;
        }
    }

    [System.Serializable]
    public class Ranking
    {
        string name;
        int score;
        string timer;

        public int Score { get => score; set => score = value; }
        public string Timer { get => timer; set => timer = value; }
        public string Name
        {
            get => name;
            set
            {
                for (int i = 0; i < 4; i++)
                {
                    name[i].ToString();
                }
                name = value;
            }
        }

        public Ranking(string nameValue, int score, string timer)
        {
            Name = nameValue;
            Score = score;
            Timer = timer;
        }
    }
    public void Save()
    {
        var data = JsonUtility.ToJson(this, true);

        Debug.Log(data);

        PlayerPrefs.SetString("SaveData", data);
    }

    public void Load()
    {
        var data = PlayerPrefs.GetString("SaveData");

        Debug.Log(data);

        JsonUtility.FromJsonOverwrite(data, this);
    }
}
