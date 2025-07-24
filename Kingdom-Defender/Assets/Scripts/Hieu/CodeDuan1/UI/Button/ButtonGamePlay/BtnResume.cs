using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : BtnAbstract<PauseUI>
{
    protected override void OnClick()
    {
        this.ResumeGame();
    }
    protected virtual void ResumeGame()
    {
        MenuManager.Instance.ResumeGame();
        this.parentCtrl.Hide();
    }
}
