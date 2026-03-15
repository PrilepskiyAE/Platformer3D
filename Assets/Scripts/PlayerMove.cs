using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Input.GetAxis("Horizontal")*_moveSpeed,0,0,ForceMode.VelocityChange);
         _rb.AddForce(-_rb.linearVelocity.x*_friction,0,0,ForceMode.VelocityChange);
    }
}
