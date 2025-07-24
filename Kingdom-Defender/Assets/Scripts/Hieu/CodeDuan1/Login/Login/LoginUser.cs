using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LoginUser : HieuMonoBehaviour
{
    [SerializeField] protected string emailUser;    

    [SerializeField] protected string passwordUser;  
    
    public void Login()
    {                
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailUser,
            Password = passwordUser
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnErrol);
    }

    private void OnErrol(PlayFabError error)
    {
        HolderLoginUI.Instance.MessageText("Đăng nhập thất bại");        
    }

    private void OnLoginSucces(LoginResult result)
    {
        HolderLoginUI.Instance.MessageText("Login");
        Debug.Log("succsess");
        GameManager.Instance.LoadScene(NameScene.MainMenu);
    }
    public string EmailUser(string emailUser)
    {
        return this.emailUser = emailUser;
    }
    public string PasswordUser(string passwordUser)
    {
        return this.passwordUser = passwordUser;
    }
}
