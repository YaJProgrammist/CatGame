using System.Collections.Generic;
using static DynamicLazerController;

public class DynamicLazerCycledBehaviorUsual : DynamicLazerCycledBehavior
{
    public DynamicLazerCycledBehaviorUsual(List<DynamicLazerCycle> currentCycles, DynamicLazer currentLazer) : base(currentCycles, currentLazer) { }

    protected override sealed void SetStateDurations()
    {
        DynamicLazerCycle currentCycle = cycles[currentCycleNumber];

        stateDurations[DynamicLazerState.Waiting] = currentCycle.WaitingTime;
        stateDurations[DynamicLazerState.Caution] = currentCycle.CautionTime;
        stateDurations[DynamicLazerState.Danger] = currentCycle.DangerTime;
    }
}
