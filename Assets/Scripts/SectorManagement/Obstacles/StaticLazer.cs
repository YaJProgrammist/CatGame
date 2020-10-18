/*
 * Obstacle that stays in the same position.
 */
using UnityEngine;

public class StaticLazer : Obstacle
{
    [SerializeField]
    private float zRotatingVelocity;

    private Vector3 rotatingVelocity;

    public StaticLazerBehavior Behavior;

    void Start()
    {
        Behavior = new StaticLazerBehaviorUsual();
        Behavior.Activate(this);

        rotatingVelocity = new Vector3(0, 0, zRotatingVelocity * Time.deltaTime);
    }

    void Update()
    {
        this.transform.Rotate(rotatingVelocity);
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
        gameManager.OnPlayerHealthAffected?.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
