﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShotAttackController : MonoBehaviour
{
    [SerializeField]
    GameObject bill;

    //public float speed;
    //public float tilt;

    //public GameObject shot;
    //public Transform shotSpawn;
    //public float fireRate;
    //private float nextFire;

    //[SerializeField]
    //GameObject getItem;
    int itemNam;

    [SerializeField]
    PlayerLifeManagement playerLifeManagement;

    //[SerializeField]
    //GameObject[] items;

    //[SerializeField]
    //Transform tran;
    //public Transform shotTarget;
    //public Transform shotTargetSpawn;

    public void SButtonDown()
    {
        Instantiate(bill, transform.position, Quaternion.identity);

        //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //GetComponent<AudioSource>().Play();
        //Instantiate(getItem, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        itemNam++;
        ShowItem(itemNam);
    }


    public void ShowItem(int namber)
    {
        for (int i = 0; i < namber; i++)
        {
            playerLifeManagement.items[i].SetActive(false);
        }
    }

    //void Start()
    //{
    //    foreach (var item in items)
    //    {
    //        item.SetActive(false);
    //    }
    //}

    //void Update()
    //{
    //    foreach (Transform shotSpawn in shotSpawn)
    //    {
    //        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    //    }
    //}
}
