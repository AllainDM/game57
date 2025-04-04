using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// public class PressurePlate : MonoBehaviour
// {
//     [SerializeField] private GateController gateController;
//     [SerializeField] private float pressDownDistance = 0.2f;
//     [SerializeField] private float minHeight = 0.5f;
    
//     private Vector3 initialLocalPos;
//     private bool isPressed = false;
//     private int objectsOnPlate = 0;

//     void Start()
//     {
//         initialLocalPos = transform.localPosition;
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player") || other.CompareTag("MovableObject"))
//         {
//             objectsOnPlate++;
//             if (!isPressed)
//             {
//                 isPressed = true;
//                 float newY = Mathf.Max(initialLocalPos.y - pressDownDistance, minHeight);
//                 transform.localPosition = new Vector3(
//                     initialLocalPos.x,
//                     newY,
//                     initialLocalPos.z
//                 );
//                 gateController.OpenGate();
//             }
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player") || other.CompareTag("MovableObject"))
//         {
//             objectsOnPlate--;
//             if (objectsOnPlate <= 0)
//             {
//                 isPressed = false;
//                 transform.localPosition = initialLocalPos;
//                 gateController.CloseGate();
//             }
//         }
//     }
// }
public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GateController gateController;
    [SerializeField] private float pressDownDistance = 0.05f;
    [SerializeField] private float pressSpeed = 3f;
    
    private Vector3 initialPosition;
    private bool isPressed = false;
    private int objectsOnPlate = 0;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 targetPosition = isPressed ? 
            initialPosition - Vector3.up * pressDownDistance : 
            initialPosition;

        // transform.position = Vector3.Lerp(transform.position, targetPosition, pressSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
    }
    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("void OnTriggerEnter(Collider other)");
        // if (other.CompareTag("MovableObject"))
        // if (other.CompareTag("Player") || other.CompareTag("MovableObject"))
        // {
            objectsOnPlate++;
            if (!isPressed)
            {
                isPressed = true;
                gateController.OpenGate();
            }
        // }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("void OnTriggerExit(Collider other)");
        // if (other.CompareTag("MovableObject"))
        // if (other.CompareTag("Player") || other.CompareTag("MovableObject"))
        // {
            objectsOnPlate--;
            if (objectsOnPlate <= 0)
            {
                isPressed = false;
                gateController.CloseGate();
            }
        // }
    }
}
