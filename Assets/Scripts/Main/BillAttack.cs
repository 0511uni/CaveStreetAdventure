using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
/// <summary>
/// お札のアクション
/// </summary>
public class BillAttack : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        
        Debug.Log(player.GetComponent<SpriteRenderer>().flipX?"playerのイラストのまま":"playerのイラストを反転");


        switch (player.GetComponent<SpriteRenderer>().flipX)
        {
            case false:
                transform.Translate(0.3f, 0, 0);
                Debug.Log("そのまま");
                break;
            case true:
                transform.Translate(-0.3f, 0, 0);
                Debug.Log("プレイヤースプライトを反転");
                break;
        }
    }

    /// <summary>
    /// このオブジェクトが画面外に出ると呼ばれる
    /// </summary>
    void OnBecameInvisible()
    {
        Debug.Log("画面外に出ました");
        Destroy(gameObject);
    }

    /// <summary>
    /// 逆に画面内に表示されたタイミングで呼ばれます
    /// </summary>
    void OnBecameVisible()
    {
        Debug.Log("画面内です");
    }
}
