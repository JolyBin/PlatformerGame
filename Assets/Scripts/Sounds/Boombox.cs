using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boombox : MonoBehaviour
{
    public AudioSource[] DedMusic;
    public Camera Camera;

    int _currentMusicIndex = 0;
    bool _isPlay;

    void PlayMusic()
    {
        if(_currentMusicIndex >= DedMusic.Length)
        {
            _currentMusicIndex = 0;
        }
        DedMusic[_currentMusicIndex].Play();
    }

    private void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.GetComponent<Boombox>() && Input.GetMouseButtonDown(0))
            {
                if (_isPlay)
                {
                    _isPlay = false;
                    DedMusic[_currentMusicIndex].Stop();
                }
                else
                {
                    _isPlay = true;
                    _currentMusicIndex++;
                    PlayMusic();
                }
                
            }
        }
    }
}
