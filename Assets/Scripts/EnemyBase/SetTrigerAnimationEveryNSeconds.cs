using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigerAnimationEveryNSeconds : MonoBehaviour
{
    public float Period = 5f;
    public Animator Animator;
    public string TrigerName = "Attack";

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= Period)
        {
            _timer = 0;
            Animator.SetTrigger(TrigerName);
        }
    }
}
