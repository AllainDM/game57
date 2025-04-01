using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToggler : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;

    private int _curLevel = 0;

    private void Start()
    {
        FirstLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (IsLastLevel())
            {
                FirstLevel();
            }
            else
            {
                NextLevel();
            }
        }
    }

    public void FirstLevel()
    {
        _curLevel = 0;
        UpdateLevel(_curLevel);
    }

    public void NextLevel()
    {
        _curLevel++;
        UpdateLevel(_curLevel);
    }

    public bool IsLastLevel()
    {
        return _curLevel == _levels.Length - 1;
    }

    private void UpdateLevel(int curLevel)
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            if (i == curLevel)
            {
                _levels[i].SetActive(true);
            }
            else
            {
                _levels[i].SetActive(false);
            }
        }
    }
}
