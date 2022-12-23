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

    public Enemy GenerateEnemy(GameObject enemy)
    {
        GameObject enemyNew = Instantiate(enemy, enemysTrans);
        GameTool.AddComponent<Enemy>(enemyNew);
        return enemyNew.GetComponent<Enemy>();
    }
}
