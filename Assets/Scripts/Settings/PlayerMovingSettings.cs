using System;
using UnityEngine;

[Serializable]
public class PlayerMovingSettings
{
    [SerializeField]
    private PlayerRunningSettings playerRunningSettings;

    [SerializeField]
    private PlayerFlyingSettings playerFlyingSettings;

    [SerializeField]
    private PlayerBoostedSettings playerBoostedSettings;

    public PlayerRunningSettings GetRunningSettings()
    {
        return playerRunningSettings;
    }

    public PlayerFlyingSettings GetFlyingSettings()
    {
        return playerFlyingSettings;
    }

    public PlayerBoostedSettings GetBoostedSettings()
    {
        return playerBoostedSettings;
    }
}
