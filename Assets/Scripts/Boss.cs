using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject cannon;

    public GameObject missileTemplate;

    public Transform firePoint1;

    public Transform firePoint2;

    public Transform firePoint3;

    public Transform battery;

    Missile missile = null;

    public Transform target;

    private float fireCanonTime=0f;

    private float UlkCD = 0f;

    protected override void InitElementOnAwake()
    {
        base.InitElementOnAwake();
    }
    protected override void InitDataOnAwake()
    {
        bullet = Resources.Load<GameObject>("Prefebs/" + "bulletEnemy");
        cannon = Resources.Load<GameObject>("Prefebs/" + "bulletBoss");
        target = GameObject.Find("Player").gameObject.transform;
    }
    protected override void Death()
    {
        
    }
    protected override void Update()
    {
        Vector3 pos = (target.position - battery.transform.position).normalized;
        battery.rotation = Quaternion.FromToRotation(Vector3.left, pos);
    }
    // Start is called before the first frame update
    protected override void OnStart()
    {
        StartCoroutine(Enter());
    }

    IEnumerator Enter()
    {
        this.gameObject.transform.position = new Vector3(17, 2, 0);
        yield return MoveTo(new Vector3(7f,2,0));
        yield return Attack();
    }
    IEnumerator Attack()
    {
        while (true)
        {
            FireBullet();
            Fire2();
            UlkCD += Time.deltaTime;
            if (UlkCD>=12f)
            {
                yield return UltraAttack();
                UlkCD = 0f;
            }
            yield return null;
        }
    }

    IEnumerator UltraAttack()
    {
        yield return MoveTo(new Vector3(7, 4, 0));
        yield return FireMissile();
        yield return MoveTo(new Vector3(7, 2, 0));
    }
    IEnumerator MoveTo(Vector3 pos)
    {
        while (true)
        {
            Vector3 dir = (pos - this.gameObject.transform.position);
            if (dir.magnitude < 0.1)
            {
                break;
            }
            this.gameObject.transform.position += dir.normalized *1f * Time.deltaTime;
            yield return null; 
        }
    }
    void Fire2()
    {
        fireCanonTime += Time.deltaTime;
        if (fireCanonTime>=5f)
        {
            GameObject cannons = Instantiate(cannon, firePoint2.position, battery.rotation);
            Bullet bulletType = cannons.GetComponent<Bullet>();
            Vector3 pos = (target.position - cannons.transform.position).normalized;
            bulletType.dir = pos;
            fireCanonTime = 0f;
        }
    }

    IEnumerator FireMissile()
    {
        ani.SetTrigger("skill");
        yield return new WaitForSeconds(1.5f);
    }
    public void OnMissileLoad()
    {
        GameObject missiles = Instantiate(missileTemplate,firePoint3.transform);
        missile = missiles.GetComponent<Missile>();
        missile.target = this.target;
    }

    public void OnMissileLaunch()
    {    
        if (missile!=null)
        { 
            missile.FireMissile();
            missile.gameObject.transform.SetParent(null);
            Destroy(missile.gameObject,5f);
        }      
    }

    void FireBullet()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= 0.5f)
        {
            Instantiate(bullet, bulletTrans.position, Quaternion.identity);
            bulletTimer = 0;
        }
    }

    protected override void Fire()
    {
        
    }
    protected override void Move()
    {
        
    }
}
