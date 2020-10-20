using System;
using UnityEngine;

[Serializable]
public class DynamicLazerBehaviorSettings
{
    [SerializeField]
    public DynamicLazerCycledBehaviorCoeffs usualCycledBehaviorСoeffs;

    [SerializeField]
    public DynamicLazerCycledBehaviorCoeffs weakenedCycledBehaviorСoeffs;

    public DynamicLazerBehaviorSettings()
    {
        usualCycledBehaviorСoeffs = new DynamicLazerCycledBehaviorCoeffs(1f, 1f, 1f);
        weakenedCycledBehaviorСoeffs = new DynamicLazerCycledBehaviorCoeffs(2f, 1.5f, 0.5f);
    }

    public DynamicLazerCycledBehaviorCoeffs GetUsualCycledBehaviorСoeffs()
    {
        return usualCycledBehaviorСoeffs;
    }

    public DynamicLazerCycledBehaviorCoeffs GetWeakenedCycledBehaviorСoeffs()
    {
        return weakenedCycledBehaviorСoeffs;
    }
}
