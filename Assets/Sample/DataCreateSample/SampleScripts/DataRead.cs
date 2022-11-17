using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRead : MonoBehaviour
{
    [SerializeField]
    DataKeep data;

    [SerializeField]
    GameStatus datSave;

    void Start()
    {
        Debug.Log(data.score);
        Debug.Log(datSave.Score);
        Debug.Log(datSave.highScore);
    }
}
