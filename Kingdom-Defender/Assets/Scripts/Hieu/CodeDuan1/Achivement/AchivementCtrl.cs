using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AchivementCtrl : HieuMonoBehaviour
{
    [SerializeField] protected List<InfoAchivementSO> achivementsSO;
    public List<InfoAchivementSO> AchivementSO => achivementsSO;
    public List<InfoAchivementSO> achivementRemove;
    public abstract EnumAchiverment enumAchivement();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAchivementsSO();
    }
    protected virtual void LoadAchivementsSO()
    {
        string name = transform.name;
        achivementsSO = Resources.LoadAll<InfoAchivementSO>(name).ToList();                
    }
    public virtual void GetSO(int id)
    {        
        foreach(InfoAchivementSO child in achivementsSO)
        {
            if (child.id != id) continue;
            if(CompleteAchivement(child)) return;
            child.requiedCountCurrent++;
            return;
        }
    }
    public virtual void GetSO(int id,int count)
    {
        foreach (InfoAchivementSO child in achivementsSO)
        {
            if (child.id != id) continue;
            CompleteAchivement(child);
            child.requiedCountCurrent+= count;            
            return;
        }
    }
    public virtual bool CompleteAchivement(InfoAchivementSO infoAchivementSO)
    {
        if (infoAchivementSO.requiedCountCurrent < infoAchivementSO.requiedCountMax) return false;
        infoAchivementSO.isComplete = true;
        achivementsSO.Remove(infoAchivementSO);        
        return true;
    }
}
