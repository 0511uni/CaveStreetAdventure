using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムがアイテムを呼ぶ
/// </summary>
public class SpecialItemCreater : MonoBehaviour
{

    [SerializeField]
    GameObject lastBigItems;

    void Start()
    {
        lastBigItems.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lastBigItems.SetActive(true);
        }   
    }
}
