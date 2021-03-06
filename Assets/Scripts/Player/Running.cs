﻿using UnityEngine;

/*
 * Behavior that pushes player forward.
 * Activated when player touches the floor.
 */
class Running : PlayerMovingBehavior
{
    private Vector2 velocityVector; //velocity of player during this behavior (horizontal)

    public Running(Rigidbody2D rigidbody) : base (rigidbody)
    {
        float horizontalSpeed = SettingsManager.GetInstance().GetPlayerSettings().GetMovingSettings().GetRunningSettings().GetRunningSpeed();
        velocityVector = new Vector2(horizontalSpeed, 0);
        currentRigidbody.velocity = velocityVector;
    }

    //Called in behavior controller's Update (once per frame)
    public override sealed void Update()
    {
        //No changes per frame
    }
}