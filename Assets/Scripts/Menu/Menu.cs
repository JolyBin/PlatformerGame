using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StateMenu
{
    Menu,
    Game
}

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuWindow;
    public GameObject MenuDie;

    public MonoBehaviour[] ComponentsToDisable;

    public StateMenu CurrentStateMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(CurrentStateMenu == StateMenu.Menu)
            {
                CurrentStateMenu = StateMenu.Game;
                CloseMenuWindow();
            }
            else
            {
                CurrentStateMenu = StateMenu.Menu;
                OpenMenuWindow();
            }
        }
    }
    public void OpenMenuWindow()
    {
        MenuButton.SetActive(false);
        MenuWindow.SetActive(true);
        SetActiveComponents(false, 0f);
    }

    public void OpenDieMenu()
    {
        MenuDie.SetActive(true);
        SetActiveComponents(false, 0f);
    }

    public void CloseMenuWindow()
    {
        MenuButton.SetActive(true);
        MenuWindow.SetActive(false);
        SetActiveComponents(true, 1f);
        
    }

    public void SetActiveComponents(bool isActive, float time)
    {
        foreach (MonoBehaviour obj in ComponentsToDisable)
        {
            obj.enabled = isActive;
        }
        Time.timeScale = time;
    }

    public void RestartLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
