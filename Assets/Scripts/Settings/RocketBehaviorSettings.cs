using System;
using UnityEngine;

[Serializable]
public class RocketBehaviorSettings
{
    [SerializeField]
    private Vector2 usualVelocity;

    [SerializeField]
    private Vector2 weakenedVelocity;

    public RocketBehaviorSettings()
    {
        usualVelocity = new Vector2(-6f, 0);
        weakenedVelocity = new Vector2(-2f, 0);
    }

    public Vector2 GetUsualVelocity()
    {
        return usualVelocity;
    }

    public Vector2 GetWeakenedVelocity()
    {
        return weakenedVelocity;
    }
}
