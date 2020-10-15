using System.Collections.Generic;
using static DynamicLazerController;

public class DynamicLazerCycledBehaviorWeakened : DynamicLazerCycledBehavior
{
    public DynamicLazerCycledBehaviorWeakened(List<DynamicLazerCycle> currentCycles, DynamicLazer currentLazer) : base(currentCycles, currentLazer) { }

    protected override sealed void SetStateDurations()
    {
        DynamicLazerCycle currentCycle = cycles[currentCycleNumber];

        stateDurations[DynamicLazerState.Waiting] = currentCycle.WaitingTime * 2;
        stateDurations[DynamicLazerState.Caution] = currentCycle.CautionTime * 1.5f;
        stateDurations[DynamicLazerState.Danger] = currentCycle.DangerTime * 0.5f;
    }
}
