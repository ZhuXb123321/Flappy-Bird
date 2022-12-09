using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static T AddComponent<T>(GameObject gameObject) where T : Component
    {
        T addObj = gameObject.GetComponent<T>();
        if (addObj==null)
        {
            addObj = gameObject.AddComponent<T>();
        }
        return addObj;
    }
}

