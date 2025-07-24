using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class RegisterUser : HieuMonoBehaviour
{
    [SerializeField] protected string userName;
    [SerializeField] protected string userEmail;
    [SerializeField] protected string userPassword;
    public virtual void Register()
    {        
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = userName,
            Email = userEmail,
            Password = userPassword,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSucces, OnError);
    }

    private void OnregisterSucces(RegisterPlayFabUserResult result)
    {
        HolderLoginUI.Instance.MessageText("Tạo tài khoản thành công");
        //this.registerHolderCtrl.buttonGoback.GoLogin();
    }
    private void OnError(PlayFabError error)
    {
        HolderLoginUI.Instance.MessageText("Tạo tài khoản thất bại");
        Debug.Log(error.GenerateErrorReport());
    }
    public string UserName(string userName)
    {
        return this.userName = userName;
    }
    public string UserEmail(string userEmail) 
    {
        return this.userEmail = userEmail; 
    }
    public string UserPassword(string userPassword) 
    {
        return this.userPassword = userPassword; 
    }
    
}
