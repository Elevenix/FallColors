using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedMovement;

    [SerializeField]
    private float speedMovementOnAir;

    [SerializeField]
    private float forceJump;

    private Rigidbody2D _rb;
    private float _axisX;
    private bool _canJump = false;
    private bool _isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_axisX * speedMovement, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(_axisX * speedMovementOnAir, _rb.velocity.y);
        }
    }
    private void Update()
    {
        if (_canJump && _isGrounded)
        {
            jump();
        }
    }

    public void OnHorizontal(InputValue val)
    {
        _axisX = val.Get<float>();
    }

    public void OnJump()
    {
        _canJump = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }

    // Jump action
    private void jump()
    {
        _canJump = false;
        _isGrounded = false;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
    }
}
