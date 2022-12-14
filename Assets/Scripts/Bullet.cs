using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SIDE side;
    public float speed=7f;
    public Vector3 dir = Vector3.zero;
    public int power;
    
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }
    protected virtual void OnStart()
    {
        dir =this.side == SIDE.Player? Vector3.right : Vector3.left;
    }
    protected virtual void OnUpdate()
    {
        BulletDisplacement();
        Vector3 pos = this.transform.position;
        Vector3 bulletPos = Camera.main.WorldToScreenPoint(pos);
        if (Screen.safeArea.Contains(bulletPos) == false)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    private void BulletDisplacement()
    {
        transform.Translate(dir*Time.deltaTime*speed);
    }
}
