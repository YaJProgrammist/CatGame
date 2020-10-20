using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DynamicLazer))]
public class DynamicLazerSkinController : MonoBehaviour
{
    private List<DynamicLazerSkin> differentDesignModeSkins;

    void Start()
    {
        differentDesignModeSkins = SettingsManager.GetInstance().GetObstaclesSettings().GetDynamicLazerSettings().GetDesignModeSkins();

        ApplyCurrentDesign();
    }

    private void ApplyCurrentDesign()
    {
        DesignMode designMode = SettingsManager.GetInstance().GetDesignSettings().GetDesignMode();

        DynamicLazer dynamicLazer = this.GetComponent<DynamicLazer>();

        foreach (DynamicLazerSkin skin in differentDesignModeSkins)
        {
            if (skin.GetDesignMode() == designMode)
            {
                dynamicLazer.SetCautionSprite(skin.GetCautionSprite());
                dynamicLazer.SetDangerSprite(skin.GetDangerSprite());
                break;
            }
        }
    }
}
