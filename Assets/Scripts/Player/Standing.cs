using UnityEngine;

/*
 * Behavior that makes player to stay in place.
 */
class Standing : PlayerMovingBehavior
{
    private Vector2 velocityVector; //velocity of player (is (0, 0))

    public Standing(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(0, 0);
        rigidbody.velocity = velocityVector;
    }

    //Called in behavior controller's Update (once per frame)
    public override sealed void Update()
    {
        //No changes per frame
    }
}