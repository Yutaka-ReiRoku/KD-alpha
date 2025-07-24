using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAchi : BtnMenuAbstract
{
    protected override void OnClick()
    {
        AchivementManager.Instance.GetAchivementType(EnumAchiverment.Hidden, 1);
    }
}
