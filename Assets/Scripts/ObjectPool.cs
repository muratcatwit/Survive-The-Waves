using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectToPool;
    public int poolSize;
    public bool canExpand=true;
    private List<GameObject> pool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new List<GameObject>(poolSize);

        for(int i = 0; i < poolSize; i++)
        {
            GameObject o = Instantiate(objectToPool, this.transform.position, Quaternion.identity,this.transform);
            pool.Add(o);
            o.SetActive(false);
        }

    }

    public GameObject getPooledObject()
    {
        foreach(GameObject o in pool)
        {
            if (o.activeInHierarchy == false)
            {
                return o;
            }
        }
        if (canExpand)
        {
            GameObject o = Instantiate(objectToPool, this.transform.position, Quaternion.identity,this.transform);
            pool.Add(o);
            o.SetActive(false);
            return o;
        } 
        return null;
    }
}
