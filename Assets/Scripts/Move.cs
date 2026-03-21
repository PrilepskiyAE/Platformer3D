using UnityEngine;

public class Move : MonoBehaviour
{
[SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveLeftSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private Transform playerTransform;
    private bool grounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);

        }

        if (Input.GetKey(KeyCode.LeftControl) && grounded)
        {
            playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3(1f, 0.7f, 1f), Time.deltaTime * 5f);
        }
        else
        {
            playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, Vector3.one, Time.deltaTime * 5f);
        }
    }

    void FixedUpdate()
    {
        float currentVelocityX = _rb.linearVelocity.x;
        float speedMultipayer = 1f;
        if (!grounded) speedMultipayer = 0.1f;

        if (_rb.linearVelocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
        {
            speedMultipayer = 0;
        }

        if (_rb.linearVelocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
        {
            speedMultipayer = 0;
        }

        if (currentVelocityX > 0.1f)
            _rb.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultipayer, 0, 0, ForceMode.VelocityChange);
        else
            _rb.AddForce(Input.GetAxis("Horizontal") * _moveLeftSpeed * speedMultipayer, 0, 0, ForceMode.VelocityChange);
        if (grounded) _rb.AddForce(-_rb.linearVelocity.x * _friction, 0, 0, ForceMode.VelocityChange);

    }

    void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            grounded = true;
        
        }


    }
    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
