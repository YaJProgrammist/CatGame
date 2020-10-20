using System;
using UnityEngine;

[Serializable]
public class PlayerBoostedSettings
{
    [SerializeField]
    private float boostSpeed;

    [SerializeField]
    private float boostDistance;

    public PlayerBoostedSettings()
    {
        boostSpeed = 10f;
        boostDistance = 100f;
    }

    public float GetBoostSpeed()
    {
        return boostSpeed;
    }

    public float GetBoostDistance()
    {
        return boostDistance;
    }
}
