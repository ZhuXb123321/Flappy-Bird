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
    public ENEMY_STATUS eNEMY_STATUS;
    private float y=0;
    // Start is called before the first frame update
    private void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefebs/" + "bulletEnemy");
        bulletTrans = transform.Find("bulletTrans");
        bullet.GetComponent<Bullet>().dir = -1;
        playerInit = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        y = Random.Range(-3, 4);
        this.transform.localPosition = new Vector3(10, y, 0);
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
        float sin_Y=0;
        if (eNEMY_STATUS==ENEMY_STATUS.Float_Enemy)
        {
            sin_Y = Mathf.Sin(Time.timeSinceLevelLoad*2);
        }
        if (eNEMY_STATUS == ENEMY_STATUS.Rapid_Enemy)
        {
            speed = 8f;
        }
        this.transform.position = new Vector3(this.transform.position.x- Time.deltaTime * speed, y+ sin_Y, 0);
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
