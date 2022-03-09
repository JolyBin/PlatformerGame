using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disable,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;

    public SpringJoint SpringJoint;
    public Transform RopeStart;
    public float Spring = 100f;
    public float Damper = 5f;
    public float MaxDistance = 20f;

    float _length;
    public RopeState CurrentRopeState;
    public RopeRender RopeRender;
    public PlayerMove PlayerMove;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shot();
        }
        if(CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if(distance > MaxDistance)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disable;
                RopeRender.Hide();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (CurrentRopeState == RopeState.Active && !PlayerMove.IsGround)
            {
                PlayerMove.Jump();
            }
            DestroySpring();
        }
        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRender.DrawRope(RopeStart.position, Hook.transform.position, _length);
        }
    }

    void Shot()
    {
        _length = 0;
        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }
        Hook.gameObject.SetActive(true);
        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;
        CurrentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (!SpringJoint)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = Spring;
            SpringJoint.damper = Damper;

            _length = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _length;
            
            
            CurrentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if(SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disable;
            Hook.gameObject.SetActive(false);
            RopeRender.Hide();
        }
    }
}
