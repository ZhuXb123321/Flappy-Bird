using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    private bool die;
    private Vector3 playerInit;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInit = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        InitPlater();
    }

    private void OnEnable()
    {
        GameManager.Instance.action = InitPlater;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.status==GAME_STATUS.Start&&die==false)
        {
            rb.simulated = true;
            Fly();
        }
    }

    void Fly()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetBool("fly", true);
            ani.SetBool("fall", false);
            rb.velocity = new Vector2(rb.velocity.x, 4);
        }
        if (rb.velocity.y<0)
        {
            ani.SetBool("fly", false);
            ani.SetBool("fall", true);
            ani.SetBool("Idle", false);
        }
    }

    public void InitPlater()
    {
        rb.simulated = false;
        die = false;
        this.transform.position = playerInit;
        ani.SetBool("death", false);
        ani.SetBool("fall", false);
    }

    void Death()
    {
        die = true;
        ani.SetBool("death", true);
        GameManager.Instance.status = GAME_STATUS.Over;
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            Death();
        }
        else if (collision.tag=="Score")
        {
            UIManager.Instance.ScoreInGame(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
           Death();
    }
}
