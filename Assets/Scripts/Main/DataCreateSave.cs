using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SaveData")]
public class DataCreateSave : ScriptableObject
{
    public int Score = 0;
    public string highScore = "High Score: ";
    public string key = "HIGH SCORE";
    public string Name = "Name:";
    public string scoreKey = "rankScore";
    public string[] scorekeys;
    public string[] namekeys;

    public List<Ranking> rankings = new List<Ranking>();


    [System.Serializable]
    public class Ranking
    {
        public string name;
        public int score;
    }
}
