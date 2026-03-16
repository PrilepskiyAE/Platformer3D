using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpSpeed;
    private bool grounded=true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rb.AddForce(0,_jumpSpeed,0,ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Input.GetAxis("Horizontal")*_moveSpeed,0,0,ForceMode.VelocityChange);
         _rb.AddForce(-_rb.linearVelocity.x*_friction,0,0,ForceMode.VelocityChange);
        
    }
    

    void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal,Vector3.up);
        if (angle < 45f)
        {
            grounded = true;
        }
        

    }
    void OnCollisionExit(Collision collision)
    {
        grounded=false;
    }
}
