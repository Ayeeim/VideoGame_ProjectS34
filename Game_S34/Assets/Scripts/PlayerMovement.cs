using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool isSprinting = false;

    public float movementSpeed = 5f;
    public float sprintingSpeed =  8f;


    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        rb.MovePosition(rb.position + dir * movementSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isSprinting= true;
            movementSpeed = sprintingSpeed;
        }
        else
        {
            isSprinting = false;
            movementSpeed = 5f;
        }
    }
}
