
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        this.offset = this.transform.position - this.Player.transform.position;
    }

    void LateUpdate()
    {
        this.transform.position = this.Player.transform.position + this.offset;
    }

    /* GameObject player;

    // Use this for initialization
    void Start()
    {
        // Playerの部分はカメラが追いかけたいオブジェクトの名前をいれる
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(
            playerPos.x, transform.position.y, transform.position.z);
    }*/
}