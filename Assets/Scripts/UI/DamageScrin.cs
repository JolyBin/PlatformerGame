using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScrin : MonoBehaviour
{
    public Image DamageImage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        DamageImage.enabled = true;
        for (float t = 1; t > 0 ; t -= Time.deltaTime)
        {
            DamageImage.color = new Color(DamageImage.color.r, DamageImage.color.g, DamageImage.color.b, t);
            yield return null;
        }
        DamageImage.enabled = false;
    }
}
