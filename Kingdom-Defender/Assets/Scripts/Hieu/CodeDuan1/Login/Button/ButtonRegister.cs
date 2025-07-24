using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRegister : BtnLoadParenAbstract<RegisterHolderCtrl>
{
    protected override void OnClick()
    {        
        this.RegisterClick();
    }
    protected virtual void RegisterClick()
    {
        LoginManager.Instance.RegisterUser.UserName(this.parentCtrl.userNameRegiaterArea.text);
        LoginManager.Instance.RegisterUser.UserEmail(this.parentCtrl.emailRegisterArea.text);
        LoginManager.Instance.RegisterUser.UserPassword(this.parentCtrl.passwordLoginArea.text);
        if (this.parentCtrl.RegisterCheckInput.CheckNullInput()) return;
        LoginManager.Instance.RegisterUser.Register();
    }
}
