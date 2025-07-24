using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchivementUI : BaseUIAbstract
{
    [SerializeField] protected List<AchivementCtrl> achivementCtrls;
    [SerializeField] protected List<InfoAchivementSO> infoSO;    
    [SerializeField] protected BtnAchivement btnAchivement;
    [SerializeField] protected List<BtnAchivement> btnAchivements;
    protected override void OnEnable()
    {
        this.LoadachivementCtrls();
        this.LoadInfoSO();
        //this.InsBtnAchivement();

    }    
    protected virtual void Start()
    {
        this.InsBtnAchivement();        
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnAchivement(); 
        btnAchivement.gameObject.SetActive(false);
    }
    protected virtual void LoadBtnAchivement()
    {
        if (this.btnAchivement != null) return;
        this.btnAchivement = GetComponentInChildren<BtnAchivement>();
    }
    protected virtual void LoadachivementCtrls()
    {        
        this.achivementCtrls = AchivementManager.Instance.AchivementCtrls;
    }   
    protected virtual void LoadInfoSO()
    {        
        if (infoSO.Count > 0) infoSO.Clear();
        foreach (AchivementCtrl achivement in this.achivementCtrls)
        {
            if (this.achivementCtrls == null) continue;
            infoSO.AddRange(achivement.AchivementSO);
        }
    }
    protected virtual void InsBtnAchivement()
    {        
        foreach (InfoAchivementSO infoAchivementSO in this.infoSO)
        {            
            BtnAchivement achivement = Instantiate(btnAchivement);
            achivement.transform.SetParent(this.btnAchivement.transform.parent);
            achivement.SetAchivement(infoAchivementSO);
            achivement.name = infoAchivementSO.name;
            achivement.gameObject.SetActive(true);
            btnAchivements.Add(achivement);
        }
    }
}
