using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _speedWall = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.localScale = new Vector3(transform.localScale.x + _speedWall * Time.deltaTime, 1, 1);
        Debug.Log("Стена растет + " + Time.deltaTime);
    }
}