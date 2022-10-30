using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BillAttack : MonoBehaviour
{
    //[SerializeField]
    //GameObject bill;
    void Update()
    {
        transform.Translate(0.3f, 0, 0);

        //if (transform.position.x > 2.0f)
        //{
        //    bill.SetActive(false);
        //   // Destroy(gameObject);
        //}
    }

    /*このオブジェクトが画面外に出ると呼ばれる*/
    private void OnBecameInvisible()
    {
        Debug.Log("画面外に出ました");
        Destroy(gameObject);
    }

    /*逆に画面内に表示されたタイミングで呼ばれます*/
    private void OnBecameVisible()
    {
        Debug.Log("画面内です");
    }
}
