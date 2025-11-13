using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPoolPrefab;
    [SerializeField] private int amountToPool;
    private List<GameObject> pooledObjects;

    public GameObject ObjectToPoolPrefab { get => objectToPoolPrefab; set => objectToPoolPrefab = value; }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tempObject;
        for (int i = 0; i < amountToPool; i++)
        {
            tempObject = Instantiate(objectToPoolPrefab);
            tempObject.SetActive(false);
            pooledObjects.Add(tempObject);
        }
    }

    private void OnDisable()
    {
        foreach (var item in pooledObjects)
        {
            Destroy(item);
        }
        pooledObjects.Clear();
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
