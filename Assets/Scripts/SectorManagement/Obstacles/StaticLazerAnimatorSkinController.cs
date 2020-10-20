using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StaticLazerAnimatorSkinController : AnimatorSkinController
{
    protected override sealed List<ObstacleAnimatorSkin> GetDesignModeSkins()
    {
        return SettingsManager.GetInstance().GetObstaclesSettings().GetStaticLazerSettings().GetDesignModeSkins();
    }
}
