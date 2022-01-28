using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{ 
    public static ObjectPooler instance;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;
    [SerializeField] private List<Pool> _pools;

    [System.Serializable]
    class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public Transform rootInactive;
    }
    

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    private void Start()
    {
        PreparePoolDictionary();
    }

    private void PreparePoolDictionary()
    {
        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objects = new Queue<GameObject>();
            var parent = pool.rootInactive;

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.SetParent(parent);
                obj.SetActive(false);
                objects.Enqueue(obj);
            }
            _poolDictionary.Add(pool.tag, objects);
        }
    }

    public static GameObject GetPooledGameObject(string tag)
    {
        if (instance._poolDictionary.ContainsKey(tag))
        {
            if (instance._poolDictionary[tag].Count <= 0)
            {
                return null;
            }
            Queue<GameObject> pool = instance._poolDictionary[tag];
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.parent = instance.transform;
            instance._poolDictionary[tag].Enqueue(obj);
            return obj;
        }
        Debug.Log($"'{tag}' tag doesn't exist");
        return null;
    }
}
