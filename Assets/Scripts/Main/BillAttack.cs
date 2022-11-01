using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
/// <summary>
/// お札のアクション
/// </summary>
public class BillAttack : MonoBehaviour
{
    [SerializeField]
    GameObject player; 
    void Update()
    {
        transform.Translate(0.3f, 0, 0);

        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            Debug.Log("反転");
        }

        //if (transform.position.x > 2.0f)
        //{
        //    bill.SetActive(false);
        //   // Destroy(gameObject);
        //}
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
