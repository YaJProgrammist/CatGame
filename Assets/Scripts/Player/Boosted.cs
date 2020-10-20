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
        PlayerBoostedSettings settings = SettingsManager.GetInstance().GetPlayerSettings().GetMovingSettings().GetBoostedSettings();

        float horizontalSpeed = settings.GetBoostSpeed();
        velocityVector = new Vector2(horizontalSpeed, 0);
        currentRigidbody.velocity = velocityVector;
        boostDistance = settings.GetBoostDistance();
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