using System.Collections.Generic;
using UnityEngine;

namespace Supporting
{
    public class ObjectPool
    {
        private List<GameObject> _pooledObjects;

        public ObjectPool(int amount, GameObject prefabObject)
        {
            _pooledObjects = new List<GameObject>();

            GameObject tmp;

            for (int i = 0; i < amount; i++)
            {
                tmp = GameObject.Instantiate(prefabObject);
                tmp.SetActive(false);
                _pooledObjects.Add(tmp);
            }
        }

        public GameObject GetObject()
        {
            for (int i = 0; i < _pooledObjects.Count; i++)
            {
                if (!_pooledObjects[i].activeInHierarchy)
                {
                    return _pooledObjects[i];
                }
            }

            return null;
        }
    }
}