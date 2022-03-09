using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;

    public Collider Collider;
    public Collider PlayerCollider;

    public RopeGun RopeGun;

    private void Start()
    {
        Physics.IgnoreCollision(Collider, PlayerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_fixedJoint)
        {
            Rigidbody rigidbody = collision.rigidbody;
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
                if (rigidbody)
                    _fixedJoint.connectedBody = rigidbody;
            RopeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if(_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
