using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

//[CustomEditor(typeof(Level))]
//public class LevelEditor : Editor
//{
//    Level level;

//    Vector2 scrollPos;

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        level = target as Level;
//        OnRulesGUI(level);
//    }

//    private void OnRulesGUI(Level level)
//    {
//        GUILayout.Label("Rules");
//        //GUILayout.BeginScrollView(scollPos);
//        GUILayout.BeginVertical();


//        for (int i = 0; i < level.Rules.Count; i++)
//        {
//            EditorGUILayout.ObjectField(level.Rules[i], typeof(Unit));
//        }
//        GUILayout.EndVertical();


//        //GUILayout.EndScrollView();
//        if (GUILayout.Button("Add Rule"))
//        {
//            level.Rules.Add(new SpawnRule());
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
