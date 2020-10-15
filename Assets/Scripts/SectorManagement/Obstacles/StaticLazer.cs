public class StaticLazer : Obstacle
{
    public StaticLazerBehavior Behavior;

    void Start()
    {
        Behavior = new StaticLazerBehaviorUsual();
        Behavior.Activate(this);
    }

    public void Refresh()
    {
        Behavior.Activate(this);
    }

    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PlayerHealthAffected.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
