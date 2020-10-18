/*
 * Bonus that slows present on scene dynamic lazers down when picked up.
 */
public class DynamicLazerWeakener : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.OnObstaclesAffected?.Invoke(SlowLazerDown);
    }

    public void SlowLazerDown(Obstacle obstacle)
    {
        if (obstacle is DynamicLazer lazer)
        {
            lazer.OnDynamicLazerControllerAffected?.Invoke((dynamicLazerController) => dynamicLazerController.Weaken());
        }
    }
}
