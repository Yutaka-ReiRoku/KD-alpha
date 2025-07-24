using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnHome : BtnMenuAbstract
{
    protected override void OnClick()
    {
        this.LoadSceneGame();
    }
    protected virtual void LoadSceneGame()
    {
        MenuManager.Instance.LoadScene(NameScene.MainMenu);
    }
}
