using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager :UnitySinglegon<UnitManager>
{
    private GameObject normal_Enemy;

    private GameObject float_Enemy;

    private GameObject rapid_Enemy;

    private GameObject boss_Enemy;

    public Transform enemysTrans;

    public List<GameObject> enemys = new List<GameObject>();

    #region 敌人生成速度
    private float normal_Speed = 2f;
    private float float_Speed = 4f;
    private float rapid_Speed = 7f;
    private float normal_Speed_Timer = 0f;
    private float float_Speed_Timer = 0f;
    private float rapid_Speed_Timer = 0f;
    #endregion
    private void Awake()
    {
        normal_Enemy = Resources.Load<GameObject>("Prefebs/" + "enemy");
        float_Enemy = Resources.Load<GameObject>("Prefebs/" + "enemy2");
        rapid_Enemy = Resources.Load<GameObject>("Prefebs/" + "enemy3");
        boss_Enemy = Resources.Load<GameObject>("Prefebs/" + "enemyBoss");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine = null;

    public void StartRun()
    {
        coroutine = StartCoroutine(GenerateEnemys());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < enemys.Count; i++)
        {
            Destroy(enemys[i]);
        }
        enemys.Clear();
    }

    IEnumerator GenerateEnemys()
    {
        while (true)
        {
            if (normal_Speed_Timer>= normal_Speed)
            {
                GenerateEnemy(normal_Enemy);
                normal_Speed_Timer = 0;
            }
            if (float_Speed_Timer>= float_Speed)
            {
                GenerateEnemy(float_Enemy);
                float_Speed_Timer = 0;
            }
            if (rapid_Speed_Timer>=rapid_Speed)
            {
                GenerateEnemy(rapid_Enemy);
                rapid_Speed_Timer = 0;
            }
            normal_Speed_Timer++;
            float_Speed_Timer++;
            rapid_Speed_Timer++;
            yield return new WaitForSeconds(1f);
        }
    }

    public Enemy GenerateEnemy(GameObject enemy)
    {
        GameObject enemyNew = Instantiate(enemy, enemysTrans);
        GameTool.AddComponent<Enemy>(enemyNew);
        //enemys.Add(enemyNew);
        return enemyNew.GetComponent<Enemy>();
    }
}
