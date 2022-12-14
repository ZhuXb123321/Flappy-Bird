using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int LevelID;
    public string Name;
    public Boss Boss;
    Boss boss=null;
    public List<SpawnRule> Rules = new List<SpawnRule>();
    private float timeSinceLevelStart = 0;
    private float levelStartTime = 0;
    private float bossTime = 10f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;
        if (timeSinceLevelStart>bossTime)
        {
            if (boss==null)
            {
                boss =(Boss)UnitManager.Instance.GenerateEnemy(this.Boss.gameObject);
            }
        }
    }
}
