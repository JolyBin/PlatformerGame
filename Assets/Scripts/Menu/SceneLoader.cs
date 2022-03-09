using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;
    public Image LoadScreen;

    private void Start()
    {
        LoadScreen.enabled = true;
        StartCoroutine(Screen());
    }

    IEnumerator Screen()
    {
        for (float i = 1; i > 0; i -= Time.unscaledDeltaTime * 0.5f)
        {
            LoadScreen.color = new Color(LoadScreen.color.r, LoadScreen.color.g, LoadScreen.color.b, i);
            yield return null;
        }
        LoadScreen.enabled = false;
    }
    public void LoadScene()
    {
        LoadScreen.enabled = true;

        StartCoroutine(LoadAsync());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<PlayerHealth>())
        {
            LoadScene();
        }
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        asyncLoad.allowSceneActivation = false;

        for (float i = 0; i < 1; i += Time.unscaledDeltaTime * 0.5f)
        {
            LoadScreen.color = new Color(LoadScreen.color.r, LoadScreen.color.g, LoadScreen.color.b, i);
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
        
        
    }
}