using System;
using UnityEngine;

[Serializable]
public class PlayerRunningSettings
{
    [SerializeField]
    private float runningSpeed;

    public PlayerRunningSettings()
    {
        runningSpeed = 1.5f;
    }

    public float GetRunningSpeed()
    {
        return runningSpeed;
    }
}
