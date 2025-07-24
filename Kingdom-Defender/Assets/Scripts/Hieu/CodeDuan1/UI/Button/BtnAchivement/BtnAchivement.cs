using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnAchivement : BtnMenuAbstract
{
    [SerializeField] protected TextMeshProUGUI textContent;
    [SerializeField] protected TextMeshProUGUI textCount;
    [SerializeField] protected InfoAchivementSO infoAchivementSO;
    [SerializeField] protected Image imageBtn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextContent();
        this.LoadTextCount();
        this.LoadImageBtn();
    }
    protected override void Start()
    {
        base.Start();
        this.BtnInfoAchivement();        
    }
    protected virtual void FixedUpdate()
    {
        this.BtnInfoAchivement();
    }
    protected virtual void LoadImageBtn()
    {
        if (this.imageBtn != null) return;
        this.imageBtn = GetComponent<Image>();
    }
    protected virtual void LoadTextContent()
    {
        if (this.textContent != null) return;
        this.textContent = transform.Find("TextContent").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadTextCount()
    {
        if (this.textCount != null) return;
        this.textCount = transform.Find("TextCount").GetComponent<TextMeshProUGUI>();
    }
    public virtual void SetAchivement(InfoAchivementSO infoAchivement)
    {
        this.infoAchivementSO = infoAchivement;
    }
    protected override void OnClick()
    {        
        this.CompleteAchivement();
    }
    protected virtual void BtnInfoAchivement()
    {
        this.textContent.text = infoAchivementSO.description;
        this.textCount.text = infoAchivementSO.requiedCountCurrent +"/" +infoAchivementSO.requiedCountMax;
    }   
    protected void CompleteAchivement()
    {
        if (infoAchivementSO.requiedCountCurrent < infoAchivementSO.requiedCountMax) return;
        this.imageBtn.color = Color.yellow;
    }
}
