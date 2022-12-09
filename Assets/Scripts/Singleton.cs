using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : new()
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    protected Singleton()
    {

    }
}

public class UnitySinglegon<T>:MonoBehaviour  where T : Component
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find(typeof(T).Name);
                if (go==null)
                {
                    Debug.LogError("���������Ҳ�������Ϊ" + typeof(T).Name + "������");
                }
                instance = go.GetComponent<T>();
            }
            return instance;
        }
    }
}
