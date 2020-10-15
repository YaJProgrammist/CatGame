using UnityEngine;

public class RotatingLazer : StaticLazer
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
}
