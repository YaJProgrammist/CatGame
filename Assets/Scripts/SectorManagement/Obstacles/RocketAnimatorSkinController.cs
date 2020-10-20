using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RocketAnimatorSkinController : AnimatorSkinController
{
    protected override sealed List<ObstacleAnimatorSkin> GetDesignModeSkins()
    {
        return SettingsManager.GetInstance().GetObstaclesSettings().GetRocketSettings().GetDesignModeSkins();
    }
}
