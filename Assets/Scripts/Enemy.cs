using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public ENEMY_STATUS eNEMY_STATUS;
    Bullet bullets = null;
    public float deathTime=7f;
    private float y=0;
    // Start is called before the first frame update
    protected override void InitElementOnAwake()
    {
        bulletTrans = transform.Find("bulletTrans");
        bullet = Resources.Load<GameObject>("Prefebs/" + "bulletEnemy");
        bullets = bullet.GetComponent<Bullet>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    protected override void InitDataOnAwake()
    {
        y = Random.Range(-3, 4);
        this.transform.position = new Vector3(10, y, 0);
        Destroy(this.gameObject, deathTime);
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (GameManager.Instance.status == GAME_STATUS.Start && die == false)
        {
            Move();
            Fire();
            if (currentHp==0)
            {
                currentHp = MaxHp;
            }
            if (bullets.power==0)
            {
                bullets.power = power;
            }
        }
    }
    //Îä×°Ð¡ÄñÒÆ¶¯
    protected override void Move()
    {
        float sin_Y = 0;
        if (eNEMY_STATUS == ENEMY_STATUS.Float_Enemy)
        {
            sin_Y = Mathf.Sin(Time.timeSinceLevelLoad * 2);
        }
        if (eNEMY_STATUS == ENEMY_STATUS.Rapid_Enemy)
        {
            speed = 8f;
        }
        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed, y + sin_Y, 0);
    }

    protected override void Fire()
    {
        bulletTimer += Time.deltaTime;
         if (bulletTimer >= 1.2f)
         {
             Instantiate(bullet, bulletTrans.position, Quaternion.identity);
             bulletTimer = 0;
         }
    }

    protected override void Death()
    {
        die = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullets = collision.GetComponent<Bullet>();
        if (bullets != null)
        {
            if (bullets.side == SIDE.Player)
            {
                Destroy(bullets.gameObject);
                currentHp-=bullets.power;
                if (currentHp<=0)
                {
                    Death();
                }
            }
        }
    }
}
