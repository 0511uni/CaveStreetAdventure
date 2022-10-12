using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeneButton : MonoBehaviour
{
    //　スタートボタンを押したら実行する
    public void TitleBackButton()
    {
        print("a");
        SceneManager.LoadScene("Title_Jump Adventure Land");
    }

    #region//Start() & Update()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
