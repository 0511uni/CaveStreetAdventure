using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataWrite : MonoBehaviour
{
    [SerializeField]
    DataKeep data;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("a");

            data.score = 100;

            SceneManager.LoadScene("DataCreateSub");
        }
    }
}
