using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecoveryUser : HieuMonoBehaviour
{
    [SerializeField] protected string userEmail;
    
    public virtual void Recovery()
    {        
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = userEmail,
            TitleId = Const.TILE_ID
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request,OnRecoverySucces, OnErrol);
    }

    private void OnRecoverySucces(SendAccountRecoveryEmailResult result)
    {

        HolderLoginUI.Instance.MessageText("Lấy mật khẩu thành công");
    }

    private void OnErrol(PlayFabError error)
    {
        HolderLoginUI.Instance.MessageText("Lấy mật khẩu thất bại");                
    }
    public string UserEmail (string userEmail)
    {
        return this.userEmail = userEmail;
    }
}
