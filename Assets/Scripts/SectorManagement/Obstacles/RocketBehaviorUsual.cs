using UnityEngine;

public class RocketBehaviorUsual : RocketBehavior
{
    public override sealed void Move(Rigidbody2D rocketRigidbody)
    {
        rocketRigidbody.velocity = new Vector2(-6f, 0);
    }
}
