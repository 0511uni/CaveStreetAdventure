using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputLimitController : MonoBehaviour
{
    [SerializeField]
    InputField inputText;


    public void CheckTextCount()
    {
        Debug.Log(inputText.text.Length);

        if (inputText.text.Length > 5)
        {
            inputText.text = inputText.text[..5];
        }
    }
}
