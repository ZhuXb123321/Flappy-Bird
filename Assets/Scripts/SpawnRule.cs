using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    public Unit Monster;
    public float InitTime;
    public float Period;
    public int MaxNum;

    public int MaxHp;
    public int Attack;

    private float timeSinceLevelStart = 0;
    private float levelStartTime = 0;
    int num = 0;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.levelStartTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;
        if (num>=MaxNum)
        {
            return;
        }
        if (timeSinceLevelStart>InitTime)
        {
            //¿ªÊ¼Ë¢¹Ö
            timer += Time.deltaTime;
            if (timer>Period)
            {
                Enemy enemy = UnitManager.Instance.GenerateEnemy(Monster.gameObject);
                num++;
                if (enemy.power==0)
                {
                    enemy.power = Attack;
                }                
                if (enemy.MaxHp==0)
                {
                    enemy.MaxHp = MaxHp;
                }
                timer = 0;
            }
        }
        
    }
}
