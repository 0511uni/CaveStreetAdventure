using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShotAttackController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    //[SerializeField]
    //GameObject getItem;
    int itemNam;
    [SerializeField]
    GameObject[] items; 

    //[SerializeField]
    //Transform tran;
    //public Transform shotTarget;
    //public Transform shotTargetSpawn;

    public void SButtonDown()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //GetComponent<AudioSource>().Play();
        //Instantiate(getItem, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        itemNam++;
        ShowItem(itemNam);
    }

    
    public void ShowItem(int namber) 
    {
        if (namber == 1)
        {
            items[0].SetActive(true);
            items[1].SetActive(false);
            items[2].SetActive(false);
            
        }
        if(namber == 2)
        {
            items[0].SetActive(true);
            items[1].SetActive(true);
            items[2].SetActive(false);
        }
        if (namber == 3)
        {
            items[0].SetActive(true);
            items[1].SetActive(true);
            items[2].SetActive(true);
        }
    }
    void Start()
    {
        //ShowItem(0);
        items[0].SetActive(false);
        items[1].SetActive(false);
        items[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform shotSpawn in shotSpawn)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
