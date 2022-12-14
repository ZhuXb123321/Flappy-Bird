using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public int LevelID;
    public string Name;
    public LEVEL_STATUS lEVEL_STATUS;
    public Boss Boss;
    Boss boss=null;
    public List<SpawnRule> Rules = new List<SpawnRule>();
    private float timeSinceLevelStart = 0;
    private float levelStartTime = 0;
    private float bossTime = 40f;
    public UnityAction<LEVEL_STATUS> gameEnd;
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
        if (lEVEL_STATUS!=LEVEL_STATUS.Null)
        {
            return;
        }
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;
        if (timeSinceLevelStart>bossTime)
        {
            if (boss==null)
            {
                boss =(Boss)UnitManager.Instance.GenerateEnemy(this.Boss.gameObject);
                boss.death += Boss_Death;
            }
        }
    }

    private void Boss_Death()
    {
        this.lEVEL_STATUS = LEVEL_STATUS.Success;
        gameEnd?.Invoke(this.lEVEL_STATUS);
    }
}
