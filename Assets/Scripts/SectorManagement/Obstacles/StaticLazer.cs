/*
 * Obstacle that stays in the same position.
 */
public class StaticLazer : Obstacle
{
    public StaticLazerBehavior Behavior;

    void Start()
    {
        Behavior = new StaticLazerBehaviorUsual();
        Behavior.Activate(this);
    }

    //Refresh lazer state according to current behavior
    public void Refresh()
    {
        Behavior.Activate(this);
    }

    //Take player's life
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PlayerHealthAffected.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
