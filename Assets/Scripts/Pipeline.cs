using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    private float speed=3f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(-1, 0,0)*Time.deltaTime*speed;
        timer += Time.deltaTime;
        if (timer>=6f)
        {
            Debug.Log("111");
            Init();
            timer = 0f;
        }
    }

    void Init()
    {
        float y = Random.Range(-2f, 2f);
        this.gameObject.transform.localPosition = new Vector3(-0, y, 0);
    }
}
