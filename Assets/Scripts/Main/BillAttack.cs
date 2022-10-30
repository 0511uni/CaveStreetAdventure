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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
