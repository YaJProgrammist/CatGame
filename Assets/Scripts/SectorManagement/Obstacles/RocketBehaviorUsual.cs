using UnityEngine;

public class RocketBehaviorUsual : RocketBehavior
{
    public override sealed void Move(Rigidbody2D rocketRigidbody)
    {
        rocketRigidbody.velocity = SettingsManager.GetInstance().GetObstaclesSettings().GetRocketSettings().GetBehaviorSettings().GetUsualVelocity();
    }
}
