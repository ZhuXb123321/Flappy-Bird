using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    private bool die;
    private Vector3 playerInit;
    public float speed = 3f;
    public Transform bulletTrans;
    public GameObject bullet;
    private float bulletTimer = 0f;
    public int currentHp; //当前血量
    private int MaxHp =100; //最大血量
    // Start is called before the first frame update
    private void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefebs/"+"bullet");
        bulletTrans = transform.Find("bulletTrans");
        playerInit = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
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
            //rb.simulated = true;
            //Fly();
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
    void Move()
    {
        ani.SetBool("move", true);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0) * Time.deltaTime * speed;
    }

    void Fire()
    {
        bulletTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (bulletTimer>0.2f)
            {
                Instantiate(bullet, bulletTrans.position, Quaternion.identity);
                bulletTimer = 0;
            }
        }
    }

    public void InitPlater()
    {
        currentHp = MaxHp;
        //rb.simulated = false;
        die = false;
        this.transform.position = playerInit;
        ani.SetBool("death", false);
        ani.SetBool("fall", false);
        UIManager.Instance.InitHealth(MaxHp, currentHp);
    }

    void Death()
    {
        die = true;
        ani.SetBool("death", true);
        ani.SetBool("move", false);
        GameManager.Instance.status = GAME_STATUS.Over;
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        if ((bullets!=null&&bullets.side == SIDE.Enemy)||enemys!=null)
        {
            UIManager.Instance.HealthUpdate(currentHp -= 10);
            if (bullets != null)
            {
                Destroy(bullets.gameObject);
            }
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
