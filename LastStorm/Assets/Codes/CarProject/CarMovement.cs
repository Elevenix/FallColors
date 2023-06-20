using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    private float speedRoll, maxSpeedRoll, smoothTime = 0.2f;

    public HingeJoint2D wheelL, wheelR;

    private float _axisX;
    private JointMotor2D motorL, motorR;
    private bool _gameStart = true;
    // Start is called before the first frame update
    void Start()
    {
        motorL = new JointMotor2D { motorSpeed = 0, maxMotorTorque = maxSpeedRoll };
        motorR = new JointMotor2D { motorSpeed = 0, maxMotorTorque = maxSpeedRoll };

        wheelL.motor = motorL;
        wheelR.motor = motorL;

        wheelL.useMotor = false;
        wheelR.useMotor = false;
    }

    private void FixedUpdate()
    {

        if (_gameStart)
        {
            motorStop();
        }
        else
        {
            driveMode();
            //driveMode2();
        }
    }

    private void driveMode()
    {
        if (_axisX < 0)
        {
            motorStart(motorL, wheelL);
        }
        else
        {
            motorL.motorSpeed = wheelL.jointSpeed;
            wheelL.motor = motorL;
            wheelL.useMotor = false;
        }

        if (_axisX > 0)
        {
            motorStart(motorR, wheelR);
        }
        else
        {
            motorR.motorSpeed = wheelR.jointSpeed;
            wheelR.motor = motorR;
            wheelR.useMotor = false;
        }
    }

    private void driveMode2()
    {
        if (_axisX < 0 || _axisX > 0)
        {
            motorStart(motorR, wheelR);
            motorStart(motorL, wheelL);
        }
        else
        {
            motorL.motorSpeed = 0;
            wheelL.useMotor = false;
            motorR.motorSpeed = 0;
            wheelR.useMotor = false;
        }
    }

    private void motorStart(JointMotor2D motor, HingeJoint2D wheel)
    {
        float currentSpeed = wheel.motor.motorSpeed;

        float refVelocity = 0f;
        float mSpeed = Mathf.SmoothDamp(currentSpeed, _axisX * speedRoll, ref refVelocity, smoothTime);
        motor.motorSpeed = mSpeed;

        wheel.motor = motor;
        wheel.useMotor = true;
    }

    private void motorStop()
    {
        motorL.motorSpeed = 0;
        motorR.motorSpeed = 0;

        wheelL.motor = motorL;
        wheelR.motor = motorL;

        wheelL.useMotor = true;
        wheelR.useMotor = true;
    }

    public void OnHorizontal(InputValue val)
    {
        if (_gameStart)
        {
            _gameStart = false;
            GameManager.GM.BeginGame();
        }
        _axisX = val.Get<float>();
    }

}
