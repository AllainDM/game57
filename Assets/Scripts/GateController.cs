using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// public class GateController : MonoBehaviour
// {
//     [SerializeField] private Transform leftGate;
//     [SerializeField] private Transform rightGate;
//     [SerializeField] private float speed = 2f;
//     [SerializeField] private float openDistance = 1.5f;
    
//     private Vector3 leftClosedLocalPos;
//     private Vector3 rightClosedLocalPos;

//     void Start()
//     {
//         // Сохраняем локальные позиции ворот
//         leftClosedLocalPos = leftGate.localPosition;
//         rightClosedLocalPos = rightGate.localPosition;
//     }

//     public void OpenGate()
//     {
//         StopAllCoroutines();
//         StartCoroutine(MoveGates(
//             leftClosedLocalPos + Vector3.left * openDistance,
//             rightClosedLocalPos + Vector3.right * openDistance
//         ));
//     }

//     public void CloseGate()
//     {
//         StopAllCoroutines();
//         StartCoroutine(MoveGates(leftClosedLocalPos, rightClosedLocalPos));
//     }

//     private IEnumerator MoveGates(Vector3 leftTarget, Vector3 rightTarget)
//     {
//         while (Vector3.Distance(leftGate.localPosition, leftTarget) > 0.01f || 
//                Vector3.Distance(rightGate.localPosition, rightTarget) > 0.01f)
//         {
//             leftGate.localPosition = Vector3.MoveTowards(
//                 leftGate.localPosition, 
//                 leftTarget, 
//                 speed * Time.deltaTime
//             );
//             rightGate.localPosition = Vector3.MoveTowards(
//                 rightGate.localPosition, 
//                 rightTarget, 
//                 speed * Time.deltaTime
//             );
//             yield return null;
//         }
//     }
// }
public class GateController : MonoBehaviour
{
    [SerializeField] private Transform leftGate;
    [SerializeField] private Transform rightGate;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float openDistance = 1.5f;
    
    private Vector3 leftStartPos;
    private Vector3 rightStartPos;
    private Vector3 leftTargetPos;
    private Vector3 rightTargetPos;

    void Start()
    {
        // Сохраняем начальные позиции ворот
        leftStartPos = leftGate.position;
        rightStartPos = rightGate.position;
        
        // Рассчитываем позиции для открытых ворот
        leftTargetPos = leftStartPos + Vector3.left * openDistance;
        rightTargetPos = rightStartPos + Vector3.right * openDistance;
    }

    public void OpenGate()
    {
        StopAllCoroutines();
        StartCoroutine(MoveGates(leftTargetPos, rightTargetPos));
    }

    public void CloseGate()
    {
        StopAllCoroutines();
        StartCoroutine(MoveGates(leftStartPos, rightStartPos));
    }

    private IEnumerator MoveGates(Vector3 leftTarget, Vector3 rightTarget)
    {
        while (Vector3.Distance(leftGate.position, leftTarget) > 0.01f || 
               Vector3.Distance(rightGate.position, rightTarget) > 0.01f)
        {
            leftGate.position = Vector3.MoveTowards(leftGate.position, leftTarget, speed * Time.deltaTime);
            rightGate.position = Vector3.MoveTowards(rightGate.position, rightTarget, speed * Time.deltaTime);
            yield return null;
        }
    }
}



