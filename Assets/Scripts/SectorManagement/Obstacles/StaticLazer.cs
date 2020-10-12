using UnityEngine;

public class StaticLazer : Obstacle
{
    protected override sealed void MakeImpact()
    {
        // TODO
        GameObject.Find("Player").GetComponent<HealthController>().DecreaseLivesCount();
        // TODO
    }
}
