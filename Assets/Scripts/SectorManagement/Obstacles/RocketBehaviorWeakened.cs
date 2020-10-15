using UnityEngine;

public class RocketBehaviorWeakened : RocketBehavior
{
    public override sealed void Move(Rigidbody2D rocketRigidbody)
    {
        rocketRigidbody.velocity = new Vector2(-2f, 0);
    }
}
