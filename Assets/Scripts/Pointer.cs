using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;
    public Transform PlayerBody;

    public float RotationSpeed = 5f;

    float _yEuler;

    private void Update()
    {
        MoveAim();
    }

    void MoveAim()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        Vector3 toAim = point - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if(toAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * RotationSpeed);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * RotationSpeed);
        }
        PlayerBody.localEulerAngles = new Vector3(0, _yEuler, 0);

        Plane newPlane = new Plane(-Vector3.forward, new Vector3(0, 0, -2));
        newPlane.Raycast(ray, out distance);
        Vector3 point2 = ray.GetPoint(distance);
        Aim.position = point2;
    }
}
