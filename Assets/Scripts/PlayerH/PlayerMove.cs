using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveLeftSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Transform playerTransform;
    private bool grounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);

        }

        if (Input.GetKey(KeyCode.LeftControl) && grounded)
        {
            playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3(1f, 0.8f, 1f), Time.deltaTime * 5f);
        }
        else
        {
            playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, Vector3.one, Time.deltaTime * 5f);
        }

    }

    private void FixedUpdate()
    {
        // _rb.AddForce(Input.GetAxis("Horizontal")*_moveSpeed,0,0,ForceMode.VelocityChange);
        //  _rb.AddForce(-_rb.linearVelocity.x*_friction,0,0,ForceMode.VelocityChange);
        // Сохраняем начальную скорость по оси X
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


        float newVelocityX = _rb.linearVelocity.x;


        if (newVelocityX > 0.1f)
        {
            _playerAnimation.WalkRight(true);
            _playerAnimation.WalkLeft(false);
        }
        else if (newVelocityX < -0.1f)
        {
            _playerAnimation.WalkRight(false);
            _playerAnimation.WalkLeft(true);
        }
        else
        {
            _playerAnimation.WalkRight(false);
            _playerAnimation.WalkLeft(false);
        }
    }


    void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            grounded = true;
            _playerAnimation.GroundAnimation(true);
        }


    }
    void OnCollisionExit(Collision collision)
    {
        grounded = false;
        _playerAnimation.GroundAnimation(false);
    }

}
