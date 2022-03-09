using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float DistanceToActivate = 20f;

    bool _isActive = true;

    Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.ObjectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distanse = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distanse > DistanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distanse < DistanceToActivate)
            {
                Activate();
            }
        }

    }
    public void Activate()
    {
        gameObject.SetActive(true);
        _isActive = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        _isActive = false;
    }

    private void OnDestroy()
    {
        _activator.ObjectsToActivate.Remove(this);
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif
}
