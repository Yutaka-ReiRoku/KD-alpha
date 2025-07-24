using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClossPauseUI : BtnAbstract<PauseUI>
{
    protected override void OnClick()
    {
        this.HideUI();
    }
    protected virtual void HideUI()
    {
        this.parentCtrl.Hide();
    }
}
