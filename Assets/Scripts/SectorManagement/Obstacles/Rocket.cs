using UnityEngine;

public class Rocket : Obstacle
{
    protected override sealed void MakeImpact()
    {
        // TODO
        GameObject.Find("Player").GetComponent<HealthController>().DecreaseLivesCount();
        // TODO
    }
}
