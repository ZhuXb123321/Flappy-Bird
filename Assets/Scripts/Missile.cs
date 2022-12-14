using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    public Transform target;

    private bool running;
    protected override void OnStart()
    {
        
    }
    protected override void OnUpdate()
    {
        if (target != null&&running==true)
        {
            Vector3 dir = (target.position - this.transform.position);

            this.transform.rotation = Quaternion.FromToRotation(Vector3.left , dir);

            this.transform.position += speed * Time.deltaTime * dir.normalized;
        }
    }

    public void FireMissile()
    {
        running = true;
    }
    // Update is called once per frame
}
