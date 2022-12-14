using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : UnitySinglegon<LevelManager>
{
    public List<Level> levels = new List<Level>();

    public int currentLevelId = 1;

    public Level level;

    public void LoadLevel(int levelID)
    {
        this.level=Instantiate<Level>(levels[levelID - 1]);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
