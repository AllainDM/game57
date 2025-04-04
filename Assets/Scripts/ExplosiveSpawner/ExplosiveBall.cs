using UnityEngine;

public class ExplosiveBall : MonoBehaviour
{
    private Vector3 _startScale = new Vector3(0, 0, 0);
    private Vector3 _endScale = new Vector3(10, 10, 10);
    private float _duration = 10.0f;
    private float _speed = 1.0f;

    private Vector3 _currentScale;
    private float _currentTime;
    
    private void Update()
    {
        _currentScale = Vector3.MoveTowards(_currentScale, _endScale, _speed * Time.deltaTime);
        transform.localScale = _currentScale;

        _currentTime += Time.deltaTime;

        if (_currentTime >= _duration)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetStartScale(Vector3 currentScale)
    {
        _currentScale = currentScale;
    }

    public void SetEndRadius(Vector3 endScale)
    {
        _endScale = endScale;
    }

    public void SetDuration(float duration)
    {
        _duration = duration;
    }

    public void Reset()
    {
        _currentScale = _startScale;
        _currentTime = 0;
    }
}
