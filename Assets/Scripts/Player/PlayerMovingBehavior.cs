using UnityEngine;

/*
 * Determines the way player moves.
 */
public abstract class PlayerMovingBehavior
{
    //Rigidbody of player
    protected Rigidbody2D currentRigidbody;

    public PlayerMovingBehavior(Rigidbody2D rigidbody)
    {
        currentRigidbody = rigidbody;
    }

    //Called in behavior controller's Update (once per frame)
    public abstract void Update();
}
