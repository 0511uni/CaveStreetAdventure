using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーのライフ管理
/// </summary>
public class PlayerLifeManagement : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            {
                GameObject gameManager = GameObject.Find("GameManager");
                gameManager.GetComponent<GameManagement>().GameClear();
            }
        }
    }
}
