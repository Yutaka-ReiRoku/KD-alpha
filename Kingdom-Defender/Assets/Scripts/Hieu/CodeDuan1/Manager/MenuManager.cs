using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : HieuSingleton<MenuManager>
{
    [SerializeField] protected bool isPause = false;
    public bool IsPause => isPause;
    public virtual void LoadScene(NameScene nameScene)
    {
        SceneManager.LoadScene(nameScene.ToString());
    }
    public virtual void ExitGame()
    {
        Application.Quit();

    }
    public virtual void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
    }
    public virtual void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;
    }
}
