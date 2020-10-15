﻿using UnityEngine;

public class RocketWeakener : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.ObstaclesAffected.Invoke(SlowRocketDown);
    }


    public void SlowRocketDown(Obstacle obstacle)
    {
        if (obstacle is Rocket rocket)
        {
            rocket.MovingBehavior = new RocketBehaviorWeakened();
            rocket.RefreshMoving();
        }
    }
}