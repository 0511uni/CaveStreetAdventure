using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
/// <summary>
/// 敵をジャンプして倒す敵ヘッドコライダー
/// </summary>
public class HeadController : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject player;

    //[SerializeField]
    //GameObject billPlefab;

    [SerializeField]
    int enemyPoint;

    [SerializeField]
    PlayerLifeManagement playerLifeManagement;

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
            enemy.GetComponent<BoxCollider2D>().enabled = false;

            //  スコアを加算します
            player.GetComponent<PlayerLifeManagement>().score += enemyPoint;

            playerLifeManagement.SoundSE.PlayOneShot(playerLifeManagement.Se1);
            //  UI の表示を最新します
            player.GetComponent<PlayerLifeManagement>().SetCountText();
        }
    }
}
