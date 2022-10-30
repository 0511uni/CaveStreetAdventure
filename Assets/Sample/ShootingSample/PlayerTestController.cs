using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerの動き
/// </summary>
public class PlayerTestController : MonoBehaviour
{
    [SerializeField]
    GameObject bill;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    float jumppower = 5;

    Rigidbody2D rbody;

    bool pushFlag;
    bool jumpFlag;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbody.AddForce(transform.up * speed);

            if (pushFlag == false)
            {
                jumpFlag = true;
                pushFlag = true;
            }
            else
            {
                pushFlag = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bill, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {

        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
}
