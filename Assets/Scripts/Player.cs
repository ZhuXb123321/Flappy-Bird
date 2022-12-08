using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetBool("fly", true);
            ani.SetBool("fall", false);
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }
        if (rb.velocity.y<0)
        {
            ani.SetBool("fly", false);
        }
    }
}
