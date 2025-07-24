using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonLogin : BtnLoadParenAbstract<LoginHolderCtrl>
{
    protected override void OnClick()
    {        
        this.LoginClick();
    }
    protected virtual void LoginClick()
    {
        LoginManager.Instance.LoginUser.EmailUser(this.parentCtrl.EnmailLoginInput.text);        
        LoginManager.Instance.LoginUser.PasswordUser(this.parentCtrl.PassWordLoginInput.text);
        if (this.parentCtrl.LoginCheckInput.CheckNullInput()) return;
        LoginManager.Instance.LoginUser.Login();
    }
}
