using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource[] TakeDamageSounds;
    public AudioSource[] IdleSounds;
    public AudioSource[] DieSounds;
    public AudioSource[] JumpSounds;
    public AudioSource[] AttackSounds;

    public AudioSource[] StopSounds;
    public float MinDeviation = 10;
    public float MaxDeviation = 20;

    float _currentDeviation;
    bool _isPlay;
    float _timerOfSound;

    private void PlayRandomSounds(AudioSource[] Sounds)
    {
        if (!_isPlay && Sounds.Length > 0)
        {
            AudioSource audiosSource = Sounds[Random.Range(0, Sounds.Length)];
            audiosSource.Play();
            _isPlay = true;
            Invoke("StopSound", audiosSource.clip.length);
        }
    }

    private void StopAllSounds()
    {
        foreach (AudioSource sound in StopSounds)
        {
            sound.Stop();
        }
        StopSound();

    }

    public void PlayRandomTakeDamageSound()
    {
        StopAllSounds();
        PlayRandomSounds(TakeDamageSounds);
    }

    public void PlayRandomIdleSound()
    {

        PlayRandomSounds(IdleSounds);
    }

    public void PlayRandomDieSound()
    {
        PlayRandomSounds(DieSounds);
    }

    public void PlayRandomJumpSound()
    {
        PlayRandomSounds(JumpSounds);
    }
    public void PlayRandomAttackSound()
    {
        StopAllSounds();
        PlayRandomSounds(AttackSounds);
    }
    void StopSound()
    {
        _isPlay = false;
    }

    private void Start()
    {
        UpdateCurrentDeviation();

    }

    private void Update()
    {
        _timerOfSound += Time.deltaTime;
        if(!_isPlay && _timerOfSound > _currentDeviation)
        {
            PlayRandomIdleSound();
            _timerOfSound = 0;
            UpdateCurrentDeviation();
        }
    }

    private void UpdateCurrentDeviation()
    {
        _currentDeviation = Random.Range(MinDeviation, MaxDeviation);
    }

    public void SetMusicEnable(bool value)
    {
        Music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void SetVolumeMusick(float value)
    {
        Music.volume = value * 0.01f;
    }
}
