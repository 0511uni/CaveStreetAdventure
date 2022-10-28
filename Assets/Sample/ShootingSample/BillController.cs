using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillController : MonoBehaviour
{

    [SerializeField]
    float speed = 200;

    Rigidbody2D rbody;
    //// Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(transform.right * speed);
            //transform.Translate(1.1f, 0, 0);

            if (transform.position.x == 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
