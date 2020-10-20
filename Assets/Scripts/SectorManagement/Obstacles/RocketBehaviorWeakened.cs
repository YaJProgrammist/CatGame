using UnityEngine;

public class RocketBehaviorWeakened : RocketBehavior
{
    public override sealed void Move(Rigidbody2D rocketRigidbody)
    {
        rocketRigidbody.velocity = SettingsManager.GetInstance().GetObstaclesSettings().GetRocketSettings().GetBehaviorSettings().GetWeakenedVelocity();
    }
}
