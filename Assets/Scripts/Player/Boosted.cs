using UnityEngine;
using UnityEngine.Events;

/*
 * Behavior that pushes player to go faster and without collisions 
 * in the beginning of the game.
 */
class Boosted : PlayerMovingBehavior 
{
    //Called when boost is finished
    public UnityAction OnBoostDone;

    private Vector2 velocityVector; //boost velocity
    private float boostDistance; //distance which player passes when boosted
    private float startX; //position of player before the boost

    public Boosted(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(10f, 0);
        currentRigidbody.velocity = velocityVector;
        boostDistance = 100;
        startX = rigidbody.transform.position.x;
    }

    //Called in behavior controller's Update (once per frame)
    public override sealed void Update()
    {
        //Checks if boost should be stopped (if player has passed needed distance)
        if (currentRigidbody.transform.position.x - startX >= boostDistance)
        {
            OnBoostDone?.Invoke();
        }
    }
}