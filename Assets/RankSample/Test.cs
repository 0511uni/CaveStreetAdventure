using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    Text text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            string scores = "A 100\nB 120\nC 130";
            text.text = scores;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetString("Rank", text.text);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            text.text = PlayerPrefs.GetString("Rank");
        }
    }
}
