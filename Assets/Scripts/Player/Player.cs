using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 4.0f;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = GameInput.Instance.GetMovementVector();

        if (inputVector.x != 0 || inputVector.z != 0)
        {
            transform.Translate(inputVector * (Time.fixedDeltaTime * _speed));
        }
    }
}
