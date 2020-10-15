using UnityEngine;

class Flying : PlayerMovingBehavior
{
    private Vector2 velocityVector;
    private float airJumpYStep;

    public Flying(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(1.5f, 0);
        airJumpYStep = 1f;

        rigidbody.velocity = velocityVector;
    }

    public override sealed void Move()
    {
        if (Input.GetButton("Jump"))
        {
            currentRigidbody.velocity = new Vector2(velocityVector.x, airJumpYStep);
        }
        else
        {
            currentRigidbody.velocity = new Vector2(velocityVector.x, -airJumpYStep);
        }
    }
}