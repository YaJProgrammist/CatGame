using UnityEngine;

class Standing : PlayerMovingBehavior
{
    private Vector2 velocityVector;

    public Standing(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(0, 0);
        rigidbody.velocity = velocityVector;
    }

    public override sealed void Move()
    {
    }
}