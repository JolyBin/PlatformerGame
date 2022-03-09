using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    public AudioSource Tesack;
    public Camera Camera;

    bool _isPlay;

    private void Start()
    {
        Tesack.Play();
        Tesack.Pause();
    }

    private void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<Laptop>() && Input.GetMouseButtonDown(0))
            {
                if(_isPlay)
                {
                    _isPlay = false;
                    Tesack.Pause();
                }
                else
                {
                    _isPlay = true;
                    Tesack.UnPause();
                }
            }
        }
    }
}
