using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCircleController : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject player;

    //[SerializeField]
    //GameObject billPlefab;

    [SerializeField]
    int enemyPoint;

    /// <summary>
    /// 当たった時の処理
    /// </summary>
    /// <param name="collision">コライダー</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //　敵を非表示にします
            enemy.SetActive(false);
            enemy.GetComponent<CircleCollider2D>().enabled = false;

            //  スコアを加算します
            player.GetComponent<PlayerLifeManagement>().score += enemyPoint;
            //  UI の表示を最新します
            player.GetComponent<PlayerLifeManagement>().SetCountText();
        }
    }
}
