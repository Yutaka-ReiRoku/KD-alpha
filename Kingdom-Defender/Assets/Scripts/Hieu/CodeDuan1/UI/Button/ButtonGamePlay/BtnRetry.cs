using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnReset : BtnMenuAbstract
{
    protected override void OnClick()
    {
        this.ResetGame();
    }
    protected virtual void ResetGame()
    {
        MenuManager.Instance.LoadScene(NameScene.GamePlay);
    }
}
