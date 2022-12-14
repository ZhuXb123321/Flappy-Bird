using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator ani;
    protected bool die;
    protected Vector3 playerInit;
    public float speed = 3f;
    public Transform bulletTrans;
    public GameObject bullet;
    protected float bulletTimer = 0f;
    protected int currentHp; //当前血量
    public int MaxHp; //最大血量
    public int power;
    // Start is called before the first frame update
    private void Awake()
    {
        InitElementOnAwake();

        InitDataOnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart()
    {

    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void InitElementOnAwake()
    {
        
    }

    protected virtual void InitDataOnAwake()
    {
        
    }

    protected virtual void Update()
    {

    }

    protected virtual void Move()
    {

    }
    protected virtual void Fire()
    {

    }
    protected virtual void Death()
    {
        
    }
}
