using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager :UnitySinglegon<UnitManager>
{
    public GameObject enemy;

    public Transform enemysTrans;

    public List<GameObject> enemys = new List<GameObject>();

    private void Awake()
    {
        enemy = Resources.Load<GameObject>("Prefebs/" + "enemy");
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
            GenerateEnemy();
            yield return new WaitForSeconds(3f);
        }
    }

    void GenerateEnemy()
    {
        GameObject enemyNew = Instantiate(enemy, enemysTrans);
        GameTool.AddComponent<Enemy>(enemyNew);
        enemys.Add(enemyNew);
        float y = Random.Range(-3, 4);
        enemyNew.transform.localPosition = new Vector3(10, y, 0);
    }
}
