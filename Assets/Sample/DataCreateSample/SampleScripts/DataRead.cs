using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRead : MonoBehaviour
{
    [SerializeField]
    DataKeep data;

    [SerializeField]
    DataCreateSave datSave;

    void Start()
    {
        Debug.Log(data.score);
        Debug.Log(datSave.score);
        Debug.Log(datSave.highScore);
    }
}
