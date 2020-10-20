using System;
using UnityEngine;

[Serializable]
public class DynamicLazerCycledBehaviorCoeffs
{
    [SerializeField]
    public float waitingTimeСoeff;

    [SerializeField]
    public float cautionTimeСoeff;

    [SerializeField]
    public float dangerTimeСoeff;

    public DynamicLazerCycledBehaviorCoeffs(float wTimeCoeff, float cTimeCoeff, float dTimeCoeff)
    {
        waitingTimeСoeff = wTimeCoeff;
        cautionTimeСoeff = cTimeCoeff;
        dangerTimeСoeff = dTimeCoeff;
    }

    public float GetWaitingTimeCoeff()
    {
        return waitingTimeСoeff;
    }

    public float GetCautionTimeCoeff()
    {
        return cautionTimeСoeff;
    }

    public float GetDangerTimeCoeff()
    {
        return dangerTimeСoeff;
    }
}
