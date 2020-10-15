public class DynamicLazerWeakener : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.ObstaclesAffected.Invoke(SlowLazerDown);
    }

    public void SlowLazerDown(Obstacle obstacle)
    {
        if (obstacle is DynamicLazer lazer)
        {
            lazer.DynamicLazerControllerAffected.Invoke((dynamicLazerController) => dynamicLazerController.Weaken());
        }
    }
}
