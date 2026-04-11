using Unity.VisualScripting;
using UnityEngine;

public class DetectedPlayer : MonoBehaviour
{

    private float detectionRange = 5f; 
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private LayerMask detectionLayerMask = -1;

    public bool IsPlayerDetected()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
       

        Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.red);

        if (Physics.Raycast(ray, detectionRange,detectionLayerMask))
        {
            return true;
        }
        else
        {
            return false;
        }

         
    }
}