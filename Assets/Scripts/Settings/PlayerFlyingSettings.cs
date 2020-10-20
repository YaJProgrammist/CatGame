using System;
using UnityEngine;

[Serializable]
public class PlayerFlyingSettings
{
    [SerializeField]
    private float flyingHorizontalSpeed;

    [SerializeField]
    private float flyingUpSpeed;

    [SerializeField]
    private float flyingDownSpeed;

    public PlayerFlyingSettings()
    {
        flyingHorizontalSpeed = 1.5f;
        flyingUpSpeed = 1f;
        flyingDownSpeed = -flyingUpSpeed;
    }

    public float GetFlyingHorizontalSpeed()
    {
        return flyingHorizontalSpeed;
    }

    public float GetFlyingUpSpeed()
    {
        return flyingUpSpeed;
    }

    public float GetFlyingDownSpeed()
    {
        return flyingDownSpeed;
    }
}
