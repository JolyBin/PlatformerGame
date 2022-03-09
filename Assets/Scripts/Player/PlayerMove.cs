using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float MoveSpeed = 15;
    public float MaxSpeed = 15;
    public float JumpSpeed = 8;
    public float friction = 1;
    public Transform PlayerCollider;
    public float FlyRotate = 10f;
    public UnityEvent EventOnJump; 

    public bool IsGround;

    int _jumpFrameCouner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            Jump();
        }
        Sit();
    }

    private void FixedUpdate()
    {
        Move();

        _jumpFrameCouner++;
        if(_jumpFrameCouner == 2)
        {
            PlayerRigidbody.freezeRotation = false;
            PlayerRigidbody.AddRelativeTorque(0f, 0f, FlyRotate, ForceMode.VelocityChange);
        }
    }

    void Move()
    {
        float speedMultiplier = 1f;

        if (!IsGround)
        {
            speedMultiplier = 0.2f; 
            if ((PlayerRigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0) || (PlayerRigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0))
            {
                speedMultiplier = 0;
            }

        }

        PlayerRigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (IsGround)
        {
            PlayerRigidbody.AddForce(-PlayerRigidbody.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15);
        }
    }

    public void Jump()
    {
        PlayerRigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCouner = 0;
        EventOnJump.Invoke();
    }

    void Sit()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C) || !IsGround)
        {
            PlayerCollider.localScale = Vector3.Lerp(PlayerCollider.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15);
        }
        else
        {
            PlayerCollider.localScale = Vector3.Lerp(PlayerCollider.localScale, Vector3.one, Time.deltaTime * 15);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45)
            {
                IsGround = true;
                PlayerRigidbody.freezeRotation = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGround = false;

    }
}
