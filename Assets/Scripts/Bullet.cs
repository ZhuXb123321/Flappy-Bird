using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SIDE side;
    private float speed=7f;
    public float dir = 1;
    public float power = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletDisplacement();
        Vector3 pos = this.transform.position;
        Vector3 bulletPos = Camera.main.WorldToScreenPoint(pos);
        if (Screen.safeArea.Contains(bulletPos)==false)
        {
            Destroy(this.gameObject);
        }
    }

    void BulletDisplacement()
    {
        transform.Translate(new Vector3(dir, 0,0)*Time.deltaTime*speed);
    }
}
