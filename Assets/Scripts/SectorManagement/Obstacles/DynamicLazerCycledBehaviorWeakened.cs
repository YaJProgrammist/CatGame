using System.Collections.Generic;
using static DynamicLazerController;

public class DynamicLazerCycledBehaviorWeakened : DynamicLazerCycledBehavior
{
    public DynamicLazerCycledBehaviorWeakened(List<DynamicLazerCycle> currentCycles, DynamicLazer currentLazer) : base(currentCycles, currentLazer)
    {
        timeCoeffs = SettingsManager.GetInstance().GetObstaclesSettings().GetDynamicLazerSettings().GetBehaviorSettings().GetWeakenedCycledBehaviorСoeffs();
    }
}
