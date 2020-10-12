using UnityEngine;
using UnityEngine.Events;

class Boosted : PlayerMovingBehavior // TODO Check if there is a collider after boost ended
{
    public UnityEvent BoostDone = new UnityEvent();

    private Vector2 velocityVector;
    private float boostDistance;
    private float startX;

    public Boosted(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(10f, 0);
        currentRigidbody.velocity = velocityVector;
        boostDistance = 100;
        startX = rigidbody.transform.position.x;
    }

    public override sealed void Move()
    {
        if (currentRigidbody.transform.position.x - startX >= boostDistance)
        {
            BoostDone?.Invoke();
        }
    }
}