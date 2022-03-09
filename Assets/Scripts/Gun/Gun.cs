using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 15;
    public float ShotPeriod = 0.3f;
    public AudioSource ShotSound;
    public GameObject Flash;

    float _timer;

    private void Start()
    {
        Flash.SetActive(false);
    }

    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (Input.GetMouseButton(0) && _timer > ShotPeriod)
        {
            _timer = 0; 
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlas", 0.08f);
    }

    void HideFlas()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
