using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public List<GameObject> objectsPool;
        public GameObject prefab;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;
    private GameObject tempObject;

    private void Awake()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].objectsPool = new List<GameObject>();
            for (int j = 0; j < pools[i].poolSize; j++)
            {
                tempObject = Instantiate(pools[i].prefab);
                tempObject.SetActive(false);
                pools[i].objectsPool.Add(tempObject);
            }
        }
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType <= pools.Length)
        {
            tempObject = pools[objectType].objectsPool[0];
            pools[objectType].objectsPool.RemoveAt(0);
            tempObject.SetActive(true);
            pools[objectType].objectsPool.Add(tempObject);
            return tempObject;
        }
        else
        {
            return null;
        }
    }

    public void HidePooledObject(GameObject obj)
    {
        tempObject = obj;
        tempObject.SetActive(false);
    }

}
