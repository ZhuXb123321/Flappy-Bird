using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private int life;
    float timer = 0;
    float InvincibleTime = 1f;
    public bool IsInvincible
    {
        get { return timer < this.InvincibleTime; }
    }
    // Start is called before the first frame update
    protected override void InitElementOnAwake()
    {
        bullet = Resources.Load<GameObject>("Prefebs/" + "bullet");
        bulletTrans = transform.Find("bulletTrans");
        playerInit = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        MaxHp = 10;
    }

    protected override void InitDataOnAwake()
    {
        Bullet bullets = bullet.GetComponent<Bullet>();
        bullets.power = 1;
        die = false;
        currentHp = MaxHp;
        life = 1;
        this.transform.position = playerInit;
        ani.SetBool("death", false);
        ani.SetBool("fall", false);
        UIManager.Instance.InitHealth(MaxHp, currentHp);
        UIManager.Instance.HealthNum(life);
    }

    public void Resurrected()
    {
        life--;
        currentHp = MaxHp;
        timer = 0;
        UIManager.Instance.HealthNum(life);
        UIManager.Instance.InitHealth(MaxHp, currentHp);
        this.transform.position = playerInit;
    }

    protected override void OnEnable()
    {
        GameManager.Instance.action = InitDataOnAwake;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (GameManager.Instance.status == GAME_STATUS.Start && die == false)
        {
            //rb.simulated = true;
            //Fly();
            timer += Time.deltaTime;
            Move();
            Fire();
        }
    }
    //第一关移动
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
        }
    }
    //武装小鸟移动
    protected override void Move()
    {
        ani.SetBool("move", true);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0) * Time.deltaTime * speed;
    }

    protected override void Fire()
    {
        bulletTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (bulletTimer > 0.2f)
            {
                Instantiate(bullet, bulletTrans.position, Quaternion.identity);
                bulletTimer = 0;
            }
        }
    }

    protected override void Death()
    {
        Resurrected();
        if (life <= 0)
        {
            die = true;
            ani.SetBool("death", true);
            ani.SetBool("move", false);
            GameManager.Instance.status = GAME_STATUS.Over;
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.currentHp<=0)
        {
            return;
        }
        if (IsInvincible)
        {
            return;
        }
        if (collision.tag == "Score")
        {
            UIManager.Instance.ScoreInGame(1);
        }
        Bullet bullets = collision.GetComponent<Bullet>();
        Enemy enemys = collision.GetComponent<Enemy>();
        if (bullets!=null&&enemys!=null)
        {
            return;
        }
        if (bullets!=null&&bullets.side == SIDE.Enemy)
        {
            UIManager.Instance.HealthUpdate(currentHp -= bullets.power);
            Destroy(bullets.gameObject);
            if (currentHp <= 0)
            {
                Death();
            }
        }
        if (enemys != null)
        {
            UIManager.Instance.HealthUpdate(currentHp-=enemys.power);
            if (currentHp <= 0)
            {
                Death();
            }
        }

        //Debug.Log(collision.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Death();
    }
}
