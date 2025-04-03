using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Supporting;

public class ExplosiveSpawner : MonoBehaviour
{
    [SerializeField] private float _distance = 10.0f;
    [SerializeField] private int _ballAmount = 10;
    [SerializeField] private float _delay = 1.0f;
    [SerializeField] private float _repeatRate = 3.0f;

    [SerializeField] private GameObject _prefabBall;

    private ObjectPool _objectPool;
    private void Start()
    {
        _objectPool = new ObjectPool(_ballAmount, _prefabBall);
        InvokeRepeating("SpawnBall", _delay, _repeatRate);
    }
    private void SpawnBall()
    {
        GameObject ball = _objectPool.GetObject();

        if (ball != null)
        {
            float randomX = Random.Range(transform.position.x - _distance, transform.position.x + _distance);
            float randomZ = Random.Range(transform.position.z - _distance, transform.position.z + _distance);
            ball.transform.position = new Vector3(randomX, 0, randomZ);
            ball.GetComponent<ExplosiveBall>().Reset();
            ball.SetActive(true);
        }
    }
}
