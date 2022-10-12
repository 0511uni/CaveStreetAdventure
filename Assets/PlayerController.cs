using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    public float speed = 15;

    public float jumppower = 8;
    new
    #region//プライベート変数　SpriteRenderer
        SpriteRenderer renderer;
    Rigidbody2D rbody;
    #endregion

    #region//プライベート変数  bool
    bool pushFlag;
    private bool jumpFlag;
    #endregion

    public void LButtonDown()
    {
        transform.Translate(-20, 0, 0);

        renderer.flipX = true;
    }

    public void RButtonDown()
    {
        transform.Translate(20, 0, 0);

        renderer.flipX = false;
    }

    public void UButtonDown()
    {
        transform.Translate(0, 20, 0);

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

    public void DButtonDown()
    {
        transform.Translate(0, -20, 0);
    }

    void Start()
    {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        renderer.flipX = false;

        rbody = GetComponent<Rigidbody2D>();
    }

    //void Update()
    //{

    //}

    void FixedUpdate()
    {
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
}
