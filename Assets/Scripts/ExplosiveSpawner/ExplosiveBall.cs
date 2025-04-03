using UnityEngine;

public class ExplosiveBall : MonoBehaviour
{
    [SerializeField] private float _duration = 10.0f;
    //

    private float _currentTime; 
    
    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _duration)
        {
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        _currentTime = 0;
    }
}
