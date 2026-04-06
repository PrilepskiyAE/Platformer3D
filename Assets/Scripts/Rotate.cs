using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotateSpeed;
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }
}
