using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSoundUI : BtnMenuAbstract
{
    [SerializeField] protected SoundUI soundUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundUI();
    }
    protected virtual void LoadSoundUI()
    {
        if (this.soundUI != null) return;
        this.soundUI = transform.Find("SoundUI").GetComponent<SoundUI>();
    }
    protected override void OnClick()
    {
        this.ShowUI();
    }
    protected virtual void ShowUI()
    {
        soundUI.Show();
    }
}
