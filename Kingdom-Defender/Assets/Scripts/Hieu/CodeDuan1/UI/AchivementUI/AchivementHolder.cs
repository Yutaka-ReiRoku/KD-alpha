using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementHolder : HieuMonoBehaviour
{
    [SerializeField] protected AchivementUI achivementUI;
    public AchivementUI AchivementUI => achivementUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAchivementUI();
    }
    protected virtual void LoadAchivementUI()
    {
        if (this.achivementUI != null) return;
        this.achivementUI = transform.Find("AchivementUI").GetComponent<AchivementUI>();
    }
}
