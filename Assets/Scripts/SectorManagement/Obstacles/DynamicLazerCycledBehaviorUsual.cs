using System.Collections.Generic;
using static DynamicLazerController;

public class DynamicLazerCycledBehaviorUsual : DynamicLazerCycledBehavior
{
    public DynamicLazerCycledBehaviorUsual(List<DynamicLazerCycle> currentCycles, DynamicLazer currentLazer) : base(currentCycles, currentLazer) 
    {
        timeCoeffs = SettingsManager.GetInstance().GetObstaclesSettings().GetDynamicLazerSettings().GetBehaviorSettings().GetUsualCycledBehaviorСoeffs();
    }
}
