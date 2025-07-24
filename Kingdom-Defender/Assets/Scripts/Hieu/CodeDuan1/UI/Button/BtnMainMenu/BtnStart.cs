using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStart : BtnMenuAbstract
{
    protected override void OnClick()
    {
        this.OnStart();
    }
    protected virtual void OnStart()
    {
        GameManager.Instance.LoadScene(NameScene.GamePlay);
    }
}
