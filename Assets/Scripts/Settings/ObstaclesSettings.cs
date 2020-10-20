using System;
using UnityEngine;

[Serializable]
public class ObstaclesSettings
{
    [SerializeField]
    private RocketSettings rocketSettings;

    [SerializeField]
    private StaticLazerSettings staticLazerSettings;

    [SerializeField]
    private DynamicLazerSettings dynamicLazerSettings;

    public RocketSettings GetRocketSettings()
    {
        return rocketSettings;
    }

    public StaticLazerSettings GetStaticLazerSettings()
    {
        return staticLazerSettings;
    }

    public DynamicLazerSettings GetDynamicLazerSettings()
    {
        return dynamicLazerSettings;
    }
}
