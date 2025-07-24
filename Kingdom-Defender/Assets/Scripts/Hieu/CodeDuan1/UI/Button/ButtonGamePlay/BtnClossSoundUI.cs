using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClossSoundUI : BtnAbstract<SoundUI>
{
    protected override void OnClick()
    {
        this.HideSoundUI();
    }
    protected virtual void HideSoundUI()
    {
        this.parentCtrl.Hide();
    }
}
