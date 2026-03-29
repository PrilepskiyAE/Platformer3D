using UnityEditorInternal;
using UnityEngine;

public class Pointer : MonoBehaviour
{
   [SerializeField] private Transform aim;
   [SerializeField] private Camera playerCamera;
    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*50,Color.yellow);
        Plane plane = new Plane(-Vector3.forward,Vector3.zero);

        float distance;
        plane.Raycast(ray,out distance);
        Vector3 point = ray.GetPoint(distance);
        Debug.Log(distance);
        aim.position = point;
        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
