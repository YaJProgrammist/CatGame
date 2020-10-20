using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RocketSettings
{
    [SerializeField]
    private RocketBehaviorSettings behaviorSettings;

    [SerializeField]
    private List<ObstacleAnimatorSkin> designModeSkins;

    public RocketBehaviorSettings GetBehaviorSettings()
    {
        return behaviorSettings;
    }

    public List<ObstacleAnimatorSkin> GetDesignModeSkins()
    {
        return designModeSkins;
    }
}
