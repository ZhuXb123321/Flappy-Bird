using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    private bool die;
    private Vector3 playerInit;
    private float speed = 4f;
    public Transform bulletTrans;
    public GameObject bullet;
    private float bulletTimer = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefebs/" + "bulletEnemy");
        bulletTrans = transform.Find("bulletTrans");
        bullet.GetComponent<Bullet>().dir = -1;
        playerInit = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        Destroy(this.gameObject, 7f);
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.status == GAME_STATUS.Start && die == false)
        {
            //rb.simulated = true;
            //Fly();
            Move();
            Fire();
        }
    }

    //Îä×°Ð¡ÄñÒÆ¶¯
    void Move()
    {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
    }

    void Fire()
    {
        bulletTimer += Time.deltaTime;
         if (bulletTimer >= 0.7f)
         {
             Instantiate(bullet, bulletTrans.position, Quaternion.identity);
             bulletTimer = 0;
         }
    }

    void Death()
    {
        die = true;
        Destroy(this.gameObject);
        UnitManager.Instance.enemys.Remove(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullets = collision.GetComponent<Bullet>();
        if (bullets != null)
        {
            if (bullets.side == SIDE.Player)
            {
                Destroy(bullets.gameObject);
                Death();
            }
        }
        Debug.Log(collision.gameObject.name);
    }
}
