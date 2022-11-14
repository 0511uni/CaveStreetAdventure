using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SaveData")]
public class DataCreateSave : ScriptableObject
{
    public string Score = "Score: ";
    public string highScore = "High Score: ";
    public string key = "HIGH SCORE";
    public string Name = "Name:";
    public string scoreKey = "rankScore";
}
