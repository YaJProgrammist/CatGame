/*
 * Bonus that turns off present on scene static lazers when picked up.
 */
public class StaticLazerWeakener : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.OnObstaclesAffected?.Invoke(ShutLazerDown);
    }

    public void ShutLazerDown(Obstacle obstacle)
    {
        if (obstacle is StaticLazer lazer)
        {
            lazer.Behavior = new StaticLazerBehaviorWeakened();
            lazer.Refresh();
        }
    }
}
