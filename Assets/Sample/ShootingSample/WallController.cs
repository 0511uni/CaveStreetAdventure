using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 壁の役割
/// </summary>
public class WallController : MonoBehaviour
{
    /// <summary>
    /// isTriggerの相手に対しての対応
    /// </summary>
    /// <param name="other">isTriggerしてる相手</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // 相手のタグがBillだったら
        if (other.gameObject.CompareTag("Bill"))
        {
            //Destroy(other.gameObject);
            other.GetComponent<BillController>().enabled = false;
        }

        // Wall自身
        if (this)
        {
            Destroy(gameObject);
        }

    }
}
