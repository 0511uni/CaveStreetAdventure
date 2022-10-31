using System.Collections;
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

    //int itemNam;

    [SerializeField]
    PlayerLifeManagement playerLifeManagement;

    [SerializeField]
    GameObject shotButton;

    //[SerializeField]
    //GameObject[] items;

    //[SerializeField]
    //Transform tran;
    //public Transform shotTarget;
    //public Transform shotTargetSpawn;

    void Start()
    {
        shotButton.SetActive(false);
    }

    public void SButtonDown()
    {
        //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //GetComponent<AudioSource>().Play();
        //Instantiate(getItem, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        //shotButton.SetActive(true);

        //if (playerLifeManagement.itemNam <= 1)
        //{
        ShotInstantiate(playerLifeManagement.itemNam);
        playerLifeManagement.itemNam--;
        playerLifeManagement.ShowItem(playerLifeManagement.itemNam);
        shotButton.SetActive(false);

        //}




        //if ()
        //{
        //    Debug.Log("0以下");
        //    ShotInstantiate();
        //}
        //else
        //{
        //    return;
        //}


    }

    void ShotInstantiate(int shotNum)
    {
        for (int i = 0; i < shotNum; i++)
        {
            Instantiate(bill, transform.position, Quaternion.identity);
        }
    }


    //public void ShowItem(int namber)
    //{
    //    for (int i = 0; i < namber; i++)
    //    {
    //        Instantiate(bill, transform.position, Quaternion.identity);
    //        playerLifeManagement.items[i].SetActive(false);
    //    }
    //}

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
