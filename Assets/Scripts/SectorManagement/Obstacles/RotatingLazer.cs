using UnityEngine;

public class RotatingLazer : Obstacle
{
    private Vector3 rotatingVelocity;

    void Start()
    {
        rotatingVelocity = new Vector3(0, 0, 10f * Time.deltaTime);
    }

    void Update()
    {
        this.transform.Rotate(rotatingVelocity);
    }

    protected override sealed void MakeImpact()
    {
        // TODO
        GameObject.Find("Player").GetComponent<HealthController>().DecreaseLivesCount();
        // TODO
    }
}
