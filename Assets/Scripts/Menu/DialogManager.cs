using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject Avatar;
    public AudioSource StartAudioDialog;
    public AudioSource TelephoneAudio;
    public AudioSource DedAudio;

    public bool IsStart;
    void Start()
    {
        if (IsStart)
        {
            StartPhone();
        }
    }

    public void StartPhone()
    {
        TelephoneAudio.Play();
        Avatar.SetActive(true);
        StartCoroutine(BlinkEffect());
        Invoke("StopTelephone", 2);
    }

    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 4; t += 1)
        {
            Avatar.SetActive(!Avatar.gameObject.activeInHierarchy);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void StopTelephone()
    {
        TelephoneAudio.Stop();
        DedAudio.Play();
        Invoke("StartDialog", 1f);
    }

    void StartDialog()
    {
        Avatar.SetActive(true);
        Dialog.SetActive(true);
        StartAudioDialog.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<PlayerHealth>())
        {
            StartPhone();
        }
    }
}
