using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DynamicLazerSettings
{
    [SerializeField]
    public DynamicLazerBehaviorSettings behaviorSettings;

    [SerializeField]
    private List<DynamicLazerSkin> designModeSkins;

    public DynamicLazerBehaviorSettings GetBehaviorSettings()
    {
        return behaviorSettings;
    }

    public List<DynamicLazerSkin> GetDesignModeSkins()
    {
        return designModeSkins;
    }
}
