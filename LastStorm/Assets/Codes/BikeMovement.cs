using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BikeMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, speedRoll, maxSpeedRoll;

    [SerializeField]
    private Rigidbody2D wheelL, wheelR;

    [SerializeField]
    private float angle45 = 0.5f;

    public WheelJoint2D wheelL2, wheelR2;

    private bool isRolling = false;
    private float _axisX;

    // Start is called before the first frame update
    void Start()
    {
        wheelL2.motor = new JointMotor2D { motorSpeed = -speedRoll, maxMotorTorque = maxSpeedRoll };
        wheelR2.motor = new JointMotor2D { motorSpeed = speedRoll, maxMotorTorque = maxSpeedRoll };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //forceMovement();
        MotorRoll();

    }

    private void forceMovement()
    {
        if (_axisX > 0)
        {

            //wheelL.AddRelativeForce(new Vector2(speed * _axisX, angle45));
            wheelR.AddForce(new Vector2(speed * _axisX, 0));
            wheelL.AddTorque(speed * _axisX);
        }
        else if (_axisX < 0)
        {
            //wheelR.AddRelativeForce(new Vector2(speed * _axisX, angle45));
            wheelL.AddForce(new Vector2(speed * _axisX, 0));
            wheelR.AddTorque(speed * _axisX);
        }
    }

    private void MotorRoll()
    {
        if (_axisX > 0)
        {
            wheelL2.useMotor = true;
        }
        else
        {
            wheelL2.useMotor = false;
        }
        
        if (_axisX < 0)
        {
            wheelR2.useMotor = true;
        }
        else
        { 
            wheelR2.useMotor = false;
        }
    }

    public void OnHorizontal(InputValue val)
    {
        _axisX = val.Get<float>();
    }

    public void OnJump()
    {
        SceneManager.LoadScene(0);
    }
}
