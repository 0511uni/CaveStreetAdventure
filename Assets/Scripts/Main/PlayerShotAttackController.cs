using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotAttackController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    //public Transform shotTarget;
    //public Transform shotTargetSpawn;

    public void SButtonDown()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //GetComponent<AudioSource>().Play();
    }
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        foreach (Transform shotSpawn in shotSpawn)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
