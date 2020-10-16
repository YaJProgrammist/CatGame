using UnityEngine;

/*
 * Behavior that pushes player forward-up when button is pressed
 * and pushes it forward-down when button is not pressed.
 * Activated when player doesn't touch the floor.
 */
class Flying : PlayerMovingBehavior
{
    private Vector2 velocityVector; //vector that determines horizontal velocity during this behavior
    private float airJumpYStep; //determines vertical velocity during this behavior (upwards of downwards respectively)

    public Flying(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(1.5f, 0);
        airJumpYStep = 1f;

        rigidbody.velocity = velocityVector;
    }

    //Called in behavior controller's Update (once per frame)
    public override sealed void Update()
    {
        if (Input.GetButton("Jump"))
        {
            //Push player up
            currentRigidbody.velocity = new Vector2(velocityVector.x, airJumpYStep);
        }
        else
        {
            //Push player down
            currentRigidbody.velocity = new Vector2(velocityVector.x, -airJumpYStep);
        }
    }
}