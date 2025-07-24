using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : HieuSingleton<GameManager>
{
    public event Action onPlayerWin;
    public event Action onPlayerLose;
    
    public virtual void PlayerWin()
    {
        onPlayerWin?.Invoke();
    }
    public virtual void PlayerLose()
    {
        onPlayerLose?.Invoke();
        Time.timeScale = 0f;
    }

    [SerializeField] protected bool isPause = false;
    public bool IsPause => isPause;
    public virtual void LoadScene(NameScene nameScene)
    {
        Time.timeScale = 1;
        isPause = false;
        SceneManager.LoadScene(nameScene.ToString());
    }
    public virtual void ExitGame()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

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
