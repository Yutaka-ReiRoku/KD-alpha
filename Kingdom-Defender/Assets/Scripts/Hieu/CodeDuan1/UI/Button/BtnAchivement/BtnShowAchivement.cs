using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnShowAchivement : BtnLoadParenAbstract<AchivementHolder>
{
    protected override void OnClick()
    {        
        this.ShowUI();
    }
    protected virtual void ShowUI()
    {
        this.parentCtrl.AchivementUI.Toggle();        
    }
}
